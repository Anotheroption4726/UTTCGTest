using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    [SerializeField] private Button deckPlayerButton;
    [SerializeField] private Button trashPilePlayerButton;
    [SerializeField] private Button handPlayerButton;

    [SerializeField] private GameObject cardListDisplay;
    [SerializeField] private GameObject CardSelectPrefab;

    private int cardInDeckIdCount = 0;
    private List<Card> deckTamer_1 = new List<Card>();
    private List<Card> trashPileTamer_1 = new List<Card>();
    private List<Card> handTamer_1 = new List<Card>();

    public List<Card> GetDeckTamer_1()
    {
        return deckTamer_1;
    }

    public List<Card> GetTrashPileTamer_1()
    {
        return trashPileTamer_1;
    }

    public List<Card> GetHandTamer_1()
    {
        return handTamer_1;
    }

    private void Awake()
    {
        deckPlayerButton.onClick.AddListener(() =>
        {
            DisplayCardList(deckTamer_1);
        });

        trashPilePlayerButton.onClick.AddListener(() =>
        {
            DisplayCardList(trashPileTamer_1);
        });

        handPlayerButton.onClick.AddListener(() =>
        {
            DisplayCardList(handTamer_1);
        });
    }

    private void Start()
    {
        DeckInit();
        ShuffleCardList(deckTamer_1);
        DrawCardFromListAddToOtherList(deckTamer_1, handTamer_1, 5, true);
        DisplayCardList(handTamer_1);
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            DrawCardFromListAddToOtherList(deckTamer_1, handTamer_1, 1, true);
            DisplayCardList(handTamer_1);
        }
    }

    public void DeckInit()
    {
        AddCardsToDeckByNameFromCollection(deckTamer_1, "Nessla", 20, false);
        AddCardsToDeckByNameFromCollection(deckTamer_1, "Barnshe", 20, false);
        AddCardsToDeckByNameFromCollection(deckTamer_1, "Gyalis", 20, false);
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

    public void DisplayCardList(List<Card> arg_cardList)
    {
        ClearCardList();

        foreach (Card lp_card in arg_cardList)
        {
            GameObject loc_instCard = Instantiate(CardSelectPrefab) as GameObject;
            loc_instCard.GetComponent<CardSelectPrefabScript>().SetCard(lp_card);
            loc_instCard.transform.SetParent(cardListDisplay.transform, false);
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

    public void DrawCardFromListAddToOtherList(List<Card> arg_cardListDraw, List<Card> arg_cardListAdd, int arg_quantity, bool arg_uncovered)
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

    public void MoveCardFromListToOtherList(List<Card> arg_cardListRemove, int arg_inDeckId, List<Card> arg_cardListAdd)
    {
        Card loc_selectedCard;

        foreach(Card card in arg_cardListRemove)
        {
            if (card.GetInDeckId() == arg_inDeckId)
            {
                loc_selectedCard = card;
                arg_cardListAdd.Add(loc_selectedCard);
                arg_cardListRemove.Remove(loc_selectedCard);
                break;
            }
        }
    }
}
