using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] private GameObject cardCollection;
    [SerializeField] private GameObject cardPrefab;

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
        Debug.Log(deckPlayer_1[0].GetName());
        Debug.Log(deckPlayer_1[1].GetName());
        Debug.Log(deckPlayer_1[2].GetName());
        Debug.Log(deckPlayer_1[3].GetName());

        DisplayCardList(deckPlayer_1);
    }

    public Card GetCardFromCollection(int arg_cardIndex)
    {
        Card returnCard = cardCollection.GetComponent<CollectionScript>().GetCardCollection()[arg_cardIndex];
        return returnCard;
    }

    public void DisplayCardList(List<Card> arg_cardList)
    {
        GameObject loc_instCard = Instantiate(cardPrefab, transform.position, transform.rotation) as GameObject;
        loc_instCard.GetComponent<CardDisplayPrefabScript>().SetCard(arg_cardList[0]);
    }
}
