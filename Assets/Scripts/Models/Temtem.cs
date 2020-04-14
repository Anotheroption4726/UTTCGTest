using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temtem
{
    private Card_Temtem card;

    public Temtem (Card_Temtem arg_card)
    {
        card = arg_card;
    }

    public Card GetCard()
    {
        return card;
    }
}
