using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CardDisplayPrefabScript : MonoBehaviour
{
    private Card card;
    private SpriteRenderer cardDisplay;

    void Awake()
    {
        cardDisplay = GetComponent<SpriteRenderer>();
    }

    public void SetCard(Card arg_card)
    {
        card = arg_card;
        cardDisplay.sprite = card.GetDisplay();
    }

    //[SerializeField] GameObject cardCollection;
    private void Start()
    {
        //System.Random rnd = new System.Random();
        //int loc_chosenIndexCard = rnd.Next(0, 3);
        //cardDisplay.sprite = cardCollection.GetComponent<CollectionScript>().GetCardCollection()[loc_chosenIndexCard].GetDisplay();
    }
}
