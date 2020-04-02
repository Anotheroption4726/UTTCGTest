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
        DeckInit();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ClearCardList();
            ShuffleCardList(deckPlayer_1);
            DisplayCardList(deckPlayer_1);
        }
    }

    public Card GetCardFromCollection(int arg_cardIndex)
    {
        return cardCollection.GetComponent<CollectionScript>().GetCardCollection()[arg_cardIndex];
    }

    public List<Card> DeckInit ()
    {
        List<Card> deck = new List<Card>();

        deckPlayer_1.Add(GetCardFromCollection(0));
        deckPlayer_1.Add(GetCardFromCollection(1));
        deckPlayer_1.Add(GetCardFromCollection(2));

        return deck;
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
