using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    private SpriteRenderer cardDisplay;
    [SerializeField] GameObject cardCollection;

    // Start is called before the first frame update
    void Awake()
    {
        cardDisplay = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        System.Random rnd = new System.Random();
        int loc_chosenIndexCard = rnd.Next(0, 3);
        cardDisplay.sprite = cardCollection.GetComponent<CollectionScript>().GetCardCollection()[loc_chosenIndexCard].GetDisplay();
    }
}
