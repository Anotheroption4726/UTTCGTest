using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    private const int TOTAL_CARD_DISPLAY_BUTTONS = 2;
    private const int TOTAL_IN_GAME_TEMTEMS = 6;

    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject outOfCanvasGameObject;

    [SerializeField] private GameObject logView;
    [SerializeField] private GameObject boardView;
    [SerializeField] private GameObject selectActionView;

    [SerializeField] private GameObject cardDetailView;
    [SerializeField] private GameObject[] cardDetailViewButtonsTable = new GameObject[TOTAL_CARD_DISPLAY_BUTTONS];
    [SerializeField] private Button[] cardDetailButtonsTable = new Button[TOTAL_CARD_DISPLAY_BUTTONS];

    [SerializeField] private LogScript gameLog;
    [SerializeField] private Text gamePrompt;

    [SerializeField] private GameObject[] playerInGameTemtemButtons = new GameObject[TOTAL_IN_GAME_TEMTEMS];

    [SerializeField] private Button backpackPlayerButton;
    [SerializeField] private Button trashPilePlayerButton;
    [SerializeField] private Button handPlayerButton;
    [SerializeField] private Button cancelActionButton;

    [SerializeField] private GameObject cardListDisplay;
    [SerializeField] private GameObject CardDisplayPrefab;

    private int cardInDeckIdCount = 0;

    private Tamer player;
    private Tamer opponent;

    private actionStateEnum curentActionState;
    private browsingLocationEnum curentBrowsingLocation;

    private List<Card> cardSelection = new List<Card>();
    private int cardSelectionTotalCards = 0;
    private int cardSelectionCurrentCards = 0;








    //
    //  _____ Getters & Setters _____
    //

    public GameObject GetCanvas()
    {
        return canvas;
    }

    public GameObject GetOutOfCanvasGameObject()
    {
        return outOfCanvasGameObject;
    }

    public GameObject GetLogView()
    {
        return logView;
    }

    public GameObject GetBoardView()
    {
        return boardView;
    }

    public GameObject GetCardDetailView()
    {
        return cardDetailView;
    }

    public GameObject[] GetCardDetailViewButtonsTable()
    {
        return cardDetailViewButtonsTable;
    }

    public Button[] GetCardDetailButtonsTable()
    {
        return cardDetailButtonsTable;
    }

    public GameObject GetSelectActionView()
    {
        return selectActionView;
    }

    public Text GetGamePrompt()
    {
        return gamePrompt;
    }

    public LogScript GetGameLog()
    {
        return gameLog;
    }

    public Tamer GetPlayer()
    {
        return player;
    }

    public GameObject GetPlayerInGameTemtemButton (int arg_PlayerInGameTemtemIndex)
    {
        return playerInGameTemtemButtons[arg_PlayerInGameTemtemIndex];
    }

    public Tamer GetOpponent()
    {
        return opponent;
    }

    public actionStateEnum GetCurrentActionState()
    {
        return curentActionState;
    }

    public void SetCurrentActionState(actionStateEnum arg_actionState)
    {
        curentActionState = arg_actionState;
    }

    public browsingLocationEnum GetcurentBrowsingLocation()
    {
        return curentBrowsingLocation;
    }

    public List<Card> GetCardSelectionList()
    {
        return cardSelection;
    }

    public void AddCardToCardSelectionList(Card arg_card)
    {
        cardSelection.Add(arg_card);
    }

    public int GetCardSelectionTotalCards()
    {
        return cardSelectionTotalCards;
    }

    public void SetCardSelectionTotalCards(int arg_cardQuantity)
    {
        cardSelectionTotalCards = arg_cardQuantity;
    }

    public int GetCardSelectionCurrentCards()
    {
        return cardSelectionCurrentCards;
    }

    public void SetCardSelectionCurrentCards(int arg_cardQuantity)
    {
        cardSelectionCurrentCards = arg_cardQuantity;
    }








    //
    //  _____ Monobehavior Functions _____
    //

    private void Awake()
    {
        backpackPlayerButton.onClick.AddListener(() =>
        {
            SetCurentBrowsingLocation(browsingLocationEnum.Backpack);
        });

        trashPilePlayerButton.onClick.AddListener(() =>
        {
            SetCurentBrowsingLocation(browsingLocationEnum.TrashPile);
        });

        handPlayerButton.onClick.AddListener(() =>
        {
            SetCurentBrowsingLocation(browsingLocationEnum.Hand);
        });

        cancelActionButton.onClick.AddListener(EndActionSelectionListener);
    }

    private void Start()
    {
        //gameLog.AddLogText("Game Started", Color.white);

        player = new Tamer("Player 1", BackpackSetup());
        ShuffleCardList(player.GetBackpack());
        DrawCardsFromListAddToOtherList(player.GetBackpack(), player.GetHand(), 5, true);

        curentActionState = actionStateEnum.Play;
        SetCurentBrowsingLocation(browsingLocationEnum.Hand);

        MoveSpecificCardFromListToOtherList(player.GetBackpack(), player.GetBackpack()[0].GetInDeckId(), player.GetTrashPile());
        player.GetTrashPile()[0].SetUncoveredStatus(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            DrawCardsFromListAddToOtherList(player.GetBackpack(), player.GetHand(), 1, true);
            SetCurentBrowsingLocation(browsingLocationEnum.Hand);
        }
    }








    //
    //  _____ Navigation & display Functions _____
    //

    public void SetCurentBrowsingLocation(browsingLocationEnum arg_rowsingLocation)
    {
        if (arg_rowsingLocation == browsingLocationEnum.Hand)
        {
            gamePrompt.text = "Hand : " + player.GetHand().Count + " Card(s)";
            DisplayCardListPlayMode(player.GetHand());
        }

        if (arg_rowsingLocation == browsingLocationEnum.Backpack)
        {
            gamePrompt.text = "Backpack : " + player.GetBackpack().Count + " Card(s)";
            DisplayCardListPlayMode(player.GetBackpack());
        }

        if (arg_rowsingLocation == browsingLocationEnum.TrashPile)
        {
            gamePrompt.text = "Trash Pile : " + player.GetTrashPile().Count + " Card(s)";
            DisplayCardListPlayMode(player.GetTrashPile());
        }

        curentBrowsingLocation = arg_rowsingLocation;
    }

    public void ToggleView(GameObject arg_view , bool arg_toggle)
    {
        if (arg_toggle)
        {
            arg_view.transform.SetParent(canvas.transform, true);
        }
        else
        {
            arg_view.transform.SetParent(outOfCanvasGameObject.transform, true);
        }
    }

    public void EndActionSelectionListener()
    {
        Debug.Log("Action cancelled");

        cardSelection = new List<Card>();
        cardSelectionTotalCards = 0;
        cardSelectionCurrentCards = 0;

        SetCurentBrowsingLocation(browsingLocationEnum.Hand);
        SetCurrentActionState(actionStateEnum.Play);

        ClearCardButtonsViewDisplay();
        ToggleView(selectActionView, false);
        ToggleView(GetLogView(), true);
        ToggleView(boardView, true);
    }

    public void ClearCardButtonsViewDisplay()
    {
        foreach (GameObject buttonView in cardDetailViewButtonsTable)
        {
            ToggleView(buttonView, false);
        }
    }

    public void DisplayCardListPlayMode(List<Card> arg_cardList)
    {
        ClearDisplayCardList();

        foreach (Card lp_card in arg_cardList)
        {
            GameObject loc_instCard = Instantiate(CardDisplayPrefab) as GameObject;
            loc_instCard.GetComponent<CardDisplayPrefabScript>().SetCard(lp_card);
            loc_instCard.transform.SetParent(cardListDisplay.transform, false);
        }
    }

    public void DisplayCardListSelectModeSingle(List<Card> arg_cardList, int arg_cardInDeckId)
    {
        ClearDisplayCardList();

        foreach (Card lp_card in arg_cardList)
        {
            if (lp_card.GetInDeckId() != arg_cardInDeckId)
            {
                GameObject loc_instCard = Instantiate(CardDisplayPrefab) as GameObject;
                loc_instCard.GetComponent<CardDisplayPrefabScript>().SetCard(lp_card);
                loc_instCard.transform.SetParent(cardListDisplay.transform, false);
            }
        }
    }

    public void DisplayCardListSelectModeList(List<Card> arg_cardList)
    {
        ClearDisplayCardList();

        foreach (Card lp_card in arg_cardList)
        {
            if (!CheckByDeckIdIfCardIsInSelectedCardList(lp_card.GetInDeckId()))
            {
                GameObject loc_instCard = Instantiate(CardDisplayPrefab) as GameObject;
                loc_instCard.GetComponent<CardDisplayPrefabScript>().SetCard(lp_card);
                loc_instCard.transform.SetParent(cardListDisplay.transform, false);
            }
        }
    }

    public void ClearDisplayCardList()
    {
        foreach (Transform child in cardListDisplay.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }








    //
    //  _____ Card manipulation Functions _____
    //

    public List<Card> BackpackSetup()
    {
        List<Card>  loc_backpack = new List<Card>();

        AddCardsToBackpackFromCollection(loc_backpack, "Nessla", 20, false);
        AddCardsToBackpackFromCollection(loc_backpack, "Barnshe", 20, false);
        AddCardsToBackpackFromCollection(loc_backpack, "Gyalis", 20, false);

        cardInDeckIdCount = 0;
        return loc_backpack;
    }

    public void AddCardsToBackpackFromCollection(List<Card> arg_cardList, string arg_cardName, int arg_quantity, bool arg_uncovered)
    {
        Card loc_selectedCard = CardCollection.GetCardTemplatebyName(arg_cardName);
        Card_Temtem loc_selectedCardTemtem;

        if (loc_selectedCard.GetCardType() == cardTypesEnum.Temtem)
        {
            loc_selectedCardTemtem = (Card_Temtem)loc_selectedCard;

            for (int i = 0; i < arg_quantity; i++)
            {
                Card loc_addedCard = CardCollection.CreateNewCardTemtemFromTemplate(loc_selectedCardTemtem);
                cardInDeckIdCount ++;
                loc_addedCard.SetInDeckId(cardInDeckIdCount);
                loc_addedCard.SetUncoveredStatus(arg_uncovered);
                arg_cardList.Add(loc_addedCard);
            }
        }
    }

    public void ShuffleCardList(List<Card> arg_cardList)
    {
        for (int i = 0; i < arg_cardList.Count; i++)
        {
            Card temp = arg_cardList[i];
            int randomIndex = Random.Range(i, arg_cardList.Count);
            arg_cardList[i] = arg_cardList[randomIndex];
            arg_cardList[randomIndex] = temp;
        }
    }

    public void DrawCardsFromListAddToOtherList(List<Card> arg_cardListDraw, List<Card> arg_cardListAdd, int arg_quantity, bool arg_uncovered)
    {
        Card loc_cardDraw;

        for (int i = 0; i < arg_quantity; i++)
        {
            if (arg_cardListDraw.Count > 0)
            {
                loc_cardDraw = arg_cardListDraw[0];
                loc_cardDraw.SetUncoveredStatus(arg_uncovered);
                arg_cardListAdd.Add(loc_cardDraw);
                arg_cardListDraw.RemoveAt(0);
            }
        }
    }

    public void MoveSpecificCardFromListToOtherList(List<Card> arg_cardListRemove, int arg_cardInDeckId, List<Card> arg_cardListAdd)
    {
        Card loc_selectedCard;

        foreach(Card lp_card in arg_cardListRemove)
        {
            if (lp_card.GetInDeckId() == arg_cardInDeckId)
            {
                loc_selectedCard = lp_card;
                arg_cardListAdd.Add(loc_selectedCard);
                arg_cardListRemove.Remove(loc_selectedCard);
                break;
            }
        }
    }

    public bool CheckByDeckIdIfCardIsInSelectedCardList(int arg_cardInDeckId)
    {
        foreach (Card lp_card in cardSelection)
        {
            if (lp_card.GetInDeckId() == arg_cardInDeckId)
            {
                return true;
            }
        }
        return false;
    }
}
