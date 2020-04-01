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
        deckPlayer_1.Add(GetCardFromCollection(1));
        deckPlayer_1.Add(GetCardFromCollection(1));
        Debug.Log(deckPlayer_1[0].GetCardType());
        Debug.Log(deckPlayer_1[1].GetCardType());
        Debug.Log(deckPlayer_1[2].GetCardType());
        Debug.Log(deckPlayer_1[3].GetCardType());

        //DisplayCardList(deckPlayer_1);
    }

    public Card GetCardFromCollection(int arg_cardIndex)
    {
        return cardCollection.GetComponent<CollectionScript>().GetCardCollection()[arg_cardIndex];
    }

    public void DisplayCardList(List<Card> arg_cardList)
    {
        Vector3 loc_displayPosition = transform.position;
        SpriteRenderer loc_cardDisplay;
        int loc_cardCount = 0;

        foreach (Card lp_card in arg_cardList)
        {
            GameObject loc_instCard = Instantiate(cardPrefab, loc_displayPosition, transform.rotation) as GameObject;
            loc_instCard.GetComponent<CardDisplayPrefabScript>().SetCard(lp_card);
            loc_cardDisplay = loc_instCard.GetComponent<SpriteRenderer>();
            loc_displayPosition.x += 150;
            loc_cardDisplay.sortingOrder = loc_cardCount;
            loc_cardCount++;
        }
    }
}
