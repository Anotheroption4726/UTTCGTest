using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
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

    public void DeckInit ()
    {
        AddCardsByNameToList(deckPlayer_1, "Nessla", 20);
        AddCardsByNameToList(deckPlayer_1, "Barnshe", 20);
        AddCardsByNameToList(deckPlayer_1, "Gyalis", 20);
    }

    public void AddCardsByNameToList(List<Card> arg_cardList, string arg_card, int arg_quantity)
    {
       for (int i = 0; i < arg_quantity; i++)
       {
            arg_cardList.Add(CardCollection.GetCardbyName(arg_card));
        }
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
