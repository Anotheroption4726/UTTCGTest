using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card
{
    //public int positionInDeck;

    private Sprite display;
    private string name;

    public Sprite GetDisplay()
    {
        return display;
    }

    public void SetDisplay(Sprite arg_sprite)
    {
        display = arg_sprite;
    }

    public string GetName()
    {
        return name;
    }

    public void SetName(string arg_name)
    {
        name = arg_name;
    }
}