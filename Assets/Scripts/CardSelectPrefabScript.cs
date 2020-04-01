using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelectPrefabScript : MonoBehaviour
{
    private Card card;
    private Image cardDisplay;

    void Awake()
    {
        cardDisplay = GetComponent<Image>();
    }

    public Card GetCard()
    {
        return card;
    }

    public void SetCard(Card arg_card)
    {
        card = arg_card;
        cardDisplay.sprite = card.GetDisplay();
    }
}
