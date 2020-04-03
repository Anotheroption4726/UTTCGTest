using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card
{
    private bool uncovered = false;
    private cardTypesEnum cardType;
    private Sprite display;
    private string name;
    private string credits;
    private cardSetEnum set;
    private cardRarityEnum rarity;

    /*
    public Card(Sprite arg_display, string arg_name)
    {
        display = arg_display;
        name = arg_name;
    }
    */

    public bool getUncoveredStatus()
    {
        return uncovered;
    }

    public void setUncoveredStatus(bool arg_uncoveredStatus)
    {
        uncovered = arg_uncoveredStatus;
    }

    public cardTypesEnum GetCardType()
    {
        return cardType;
    }

    public void SetCardType(cardTypesEnum arg_cardType)
    {
        cardType = arg_cardType;
    }

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

    public string GetCredits()
    {
        return credits;
    }

    public void SetCredits(string arg_credits)
    {
        credits = arg_credits;
    }

    public cardSetEnum GetCardSet()
    {
        return set;
    }

    public void SetCardSet(cardSetEnum arg_cardSet)
    {
        set = arg_cardSet;
    }

    public cardRarityEnum GetCardRarity()
    {
        return rarity;
    }

    public void SetCardRarity(cardRarityEnum arg_cardRarity)
    {
        rarity = arg_cardRarity;
    }
}