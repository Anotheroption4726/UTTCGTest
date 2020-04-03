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

    public List<Card> deckTamer_1;
    private List<Card> trashPileTamer_1;
    public List<Card> handTamer_1;

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

        deckTamer_1 = new List<Card>();
        trashPileTamer_1 = new List<Card>();
        handTamer_1 = new List<Card>();
    }

    private void Start()
    {
        DeckInit();
        ShuffleCardList(deckTamer_1);
        AddCardsByNameFromCollectionToList(handTamer_1, "Nessla", 1, true);
        DisplayCardList(handTamer_1);
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown("space"))
        {

        }
        */
    }

    public void DeckInit ()
    {
        AddCardsByNameFromCollectionToList(deckTamer_1, "Nessla", 20, false);
        AddCardsByNameFromCollectionToList(deckTamer_1, "Barnshe", 20, false);
        AddCardsByNameFromCollectionToList(deckTamer_1, "Gyalis", 20, false);
    }

    public void AddCardsByNameFromCollectionToList(List<Card> arg_cardList, string arg_cardName, int arg_quantity, bool arg_uncovered)
    {
        Card loc_selectedCard = CardCollection.GetCardTemplatebyName(arg_cardName);
        Card_Temtem loc_selectedCardTemtem;

        if (loc_selectedCard.GetCardType() == cardTypesEnum.Temtem)
        {
            loc_selectedCardTemtem = (Card_Temtem)loc_selectedCard;

            for (int i = 0; i < arg_quantity; i++)
            {
                Card loc_addedCard = CardCollection.CreateNewCardTemtemFromTemplate(loc_selectedCardTemtem);
                loc_addedCard.setUncoveredStatus(arg_uncovered);
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
}
