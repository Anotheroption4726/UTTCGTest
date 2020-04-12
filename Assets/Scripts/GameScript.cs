using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    private const int TOTAL_CARD_DISPLAY_BUTTONS = 2;

    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject outOfCanvasGameObject;
    [SerializeField] private GameObject boardView;
    [SerializeField] private GameObject cardDetailView;
    [SerializeField] private GameObject[] cardDetailViewButtonsTable = new GameObject[TOTAL_CARD_DISPLAY_BUTTONS];
    [SerializeField] private GameObject selectActionView;

    [SerializeField] private Text gamePrompt;

    [SerializeField] private Button backpackPlayerButton;
    [SerializeField] private Button trashPilePlayerButton;
    [SerializeField] private Button handPlayerButton;
    [SerializeField] private Button cancelActionButton;

    [SerializeField] private GameObject cardListDisplay;
    [SerializeField] private GameObject CardSelectPrefab;

    private int cardInDeckIdCount = 0;
    private List<Card> backpackTamer_1 = new List<Card>();
    private List<Card> trashPileTamer_1 = new List<Card>();
    private List<Card> handTamer_1 = new List<Card>();

    private actionStateEnum curentActionState;
    private browsingLocationEnum curentBrowsingLocation;

    private List<Card> cardSelection = new List<Card>();
    private int cardSelectionTotalCards;
    private int cardSelectionCurrentCards;

    public Text GetGamePrompt()
    {
        return gamePrompt;
    }

    public List<Card> GetDeckTamer_1()
    {
        return backpackTamer_1;
    }

    public List<Card> GetTrashPileTamer_1()
    {
        return trashPileTamer_1;
    }

    public List<Card> GetHandTamer_1()
    {
        return handTamer_1;
    }

    public actionStateEnum GetcurentActionState()
    {
        return curentActionState;
    }

    public void SetCurentActionState(actionStateEnum arg_actionState)
    {
        curentActionState = arg_actionState;
    }

    public browsingLocationEnum GetcurentBrowsingLocation()
    {
        return curentBrowsingLocation;
    }

    public void SetcurentBrowsingLocation(browsingLocationEnum arg_rowsingLocation)
    {
        if (arg_rowsingLocation == browsingLocationEnum.Hand)
        {
            gamePrompt.text = "Hand : " + handTamer_1.Count + " Card(s)";
            DisplayCardListPlayMode(handTamer_1);
        }

        if (arg_rowsingLocation == browsingLocationEnum.Backpack)
        {
            gamePrompt.text = "Backpack : " + backpackTamer_1.Count + " Card(s)";
            DisplayCardListPlayMode(backpackTamer_1);
        }

        if (arg_rowsingLocation == browsingLocationEnum.TrashPile)
        {
            gamePrompt.text = "Trash Pile : " + trashPileTamer_1.Count + " Card(s)";
            DisplayCardListPlayMode(trashPileTamer_1);
        }

        curentBrowsingLocation = arg_rowsingLocation;
    }

    public List<Card> GetcardSelection()
    {
        return cardSelection;
    }

    public void AddcardSelection(Card arg_card)
    {
        cardSelection.Add(arg_card);
    }

    private void Awake()
    {
        backpackPlayerButton.onClick.AddListener(() =>
        {
            SetcurentBrowsingLocation(browsingLocationEnum.Backpack);
        });

        trashPilePlayerButton.onClick.AddListener(() =>
        {
            SetcurentBrowsingLocation(browsingLocationEnum.TrashPile);
        });

        handPlayerButton.onClick.AddListener(() =>
        {
            SetcurentBrowsingLocation(browsingLocationEnum.Hand);
        });

        cancelActionButton.onClick.AddListener(CancelActionSelectionListener);
    }

    private void Start()
    {
        DeckInit();
        ShuffleCardList(backpackTamer_1);
        DrawCardsFromListAddToOtherList(backpackTamer_1, handTamer_1, 5, true);
        curentActionState = actionStateEnum.Play;
        SetcurentBrowsingLocation(browsingLocationEnum.Hand);

        MoveSpecificCardFromListToOtherList(backpackTamer_1, backpackTamer_1[0].GetInDeckId(), trashPileTamer_1);
        trashPileTamer_1[0].SetUncoveredStatus(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            DrawCardsFromListAddToOtherList(backpackTamer_1, handTamer_1, 1, true);
            SetcurentBrowsingLocation(browsingLocationEnum.Hand);
        }
    }

    public void DeckInit()
    {
        AddCardsToDeckByNameFromCollection(backpackTamer_1, "Nessla", 20, false);
        AddCardsToDeckByNameFromCollection(backpackTamer_1, "Barnshe", 20, false);
        AddCardsToDeckByNameFromCollection(backpackTamer_1, "Gyalis", 20, false);
        cardInDeckIdCount = 0;
    }

    public void AddCardsToDeckByNameFromCollection(List<Card> arg_cardList, string arg_cardName, int arg_quantity, bool arg_uncovered)
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

    public void DisplayCardListPlayMode(List<Card> arg_cardList)
    {
        ClearCardList();

        foreach (Card lp_card in arg_cardList)
        {
            GameObject loc_instCard = Instantiate(CardSelectPrefab) as GameObject;
            loc_instCard.GetComponent<CardSelectPrefabScript>().SetCard(lp_card);
            loc_instCard.transform.SetParent(cardListDisplay.transform, false);
        }
    }

    public void DisplayCardListSelectMode(List<Card> arg_cardList, int arg_cardInDeckId)
    {
        ClearCardList();

        foreach (Card lp_card in arg_cardList)
        {
            if (lp_card.GetInDeckId() != arg_cardInDeckId)
            {
                GameObject loc_instCard = Instantiate(CardSelectPrefab) as GameObject;
                loc_instCard.GetComponent<CardSelectPrefabScript>().SetCard(lp_card);
                loc_instCard.transform.SetParent(cardListDisplay.transform, false);
            }
        }
    }

    public void ClearCardList()
    {
        foreach (Transform child in cardListDisplay.transform)
        {
            GameObject.Destroy(child.gameObject);
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

        foreach(Card card in arg_cardListRemove)
        {
            if (card.GetInDeckId() == arg_cardInDeckId)
            {
                loc_selectedCard = card;
                arg_cardListAdd.Add(loc_selectedCard);
                arg_cardListRemove.Remove(loc_selectedCard);
                break;
            }
        }
    }

    void CancelActionSelectionListener()
    {
        Debug.Log("Action cancelled");

        cardDetailViewButtonsTable[0].transform.SetParent(outOfCanvasGameObject.transform, true);
        cardDetailViewButtonsTable[1].transform.SetParent(outOfCanvasGameObject.transform, true);

        cardDetailView.transform.SetParent(outOfCanvasGameObject.transform, true);
        boardView.transform.SetParent(canvas.transform, true);

        SetcurentBrowsingLocation(browsingLocationEnum.Hand);
        SetCurentActionState(actionStateEnum.Play);
    }
}
