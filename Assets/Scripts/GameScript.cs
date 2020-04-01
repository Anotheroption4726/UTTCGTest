using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] private GameObject cardCollection;

    [SerializeField] private GameObject cardPrefab;

    [SerializeField] private GameObject cardListDisplay;
    [SerializeField] private GameObject CardSelectPrefab;

    private List<Card> deckPlayer_1;
    private List<Card> trashPilePlayer_1;
    private List<Card> handPlayer_1;

    private void Awake()
    {
        deckPlayer_1 = new List<Card>();
        trashPilePlayer_1 = new List<Card>();
        handPlayer_1 = new List<Card>();
    }

    private void Start()
    {

        deckPlayer_1.Add(GetCardFromCollection(0));
        deckPlayer_1.Add(GetCardFromCollection(0));
        deckPlayer_1.Add(GetCardFromCollection(1));
        deckPlayer_1.Add(GetCardFromCollection(2));
        deckPlayer_1.Add(GetCardFromCollection(1));
        deckPlayer_1.Add(GetCardFromCollection(1));
        deckPlayer_1.Add(GetCardFromCollection(0));
        deckPlayer_1.Add(GetCardFromCollection(0));
        deckPlayer_1.Add(GetCardFromCollection(1));
        deckPlayer_1.Add(GetCardFromCollection(2));
        deckPlayer_1.Add(GetCardFromCollection(1));
        deckPlayer_1.Add(GetCardFromCollection(1));
        deckPlayer_1.Add(GetCardFromCollection(0));
        deckPlayer_1.Add(GetCardFromCollection(0));
        deckPlayer_1.Add(GetCardFromCollection(1));
        deckPlayer_1.Add(GetCardFromCollection(2));
        deckPlayer_1.Add(GetCardFromCollection(1));
        deckPlayer_1.Add(GetCardFromCollection(1));
        deckPlayer_1.Add(GetCardFromCollection(0));
        deckPlayer_1.Add(GetCardFromCollection(0));
        deckPlayer_1.Add(GetCardFromCollection(1));
        deckPlayer_1.Add(GetCardFromCollection(2));
        deckPlayer_1.Add(GetCardFromCollection(1));
        deckPlayer_1.Add(GetCardFromCollection(1));

        DisplayCardList(deckPlayer_1);
    }

    public Card GetCardFromCollection(int arg_cardIndex)
    {
        return cardCollection.GetComponent<CollectionScript>().GetCardCollection()[arg_cardIndex];
    }

    public void DisplayCardList(List<Card> arg_cardList)
    {
        foreach (Card lp_card in arg_cardList)
        {
            GameObject loc_instCard = Instantiate(CardSelectPrefab) as GameObject;
            loc_instCard.GetComponent<CardSelectPrefabScript>().SetCard(lp_card);
            loc_instCard.transform.SetParent(cardListDisplay.transform, false);
        }
    }
}
