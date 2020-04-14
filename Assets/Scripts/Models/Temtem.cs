using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temtem
{
    private Card_Temtem card;

    private int inGameIndex;

    private int maximumHp;
    private int currentHp;

    private int maximumSta;
    private int currentSta;

    private int currentAtk;
    private int currentSpd;

    public Temtem (Card_Temtem arg_card)
    {
        card = arg_card;

        maximumHp = arg_card.GetHp();
        currentHp = arg_card.GetHp();

        maximumSta = arg_card.GetSta();
        currentSta = arg_card.GetSta();

        currentAtk = arg_card.GetAtk();
        currentSpd = arg_card.GetSpd();
    }

    public Card GetCard ()
    {
        return card;
    }

    public int GetInGameIndex ()
    {
        return inGameIndex;
    }

    public void SetInGameIndex (int arg_inGameIndex)
    {
        inGameIndex = arg_inGameIndex;
    }

    public int GetMaximumHp()
    {
        return maximumHp;
    }

    public void SetMaximumHp(int arg_maximumHp)
    {
        maximumHp = arg_maximumHp;
    }

    public int GetCurrentHp ()
    {
        return currentHp;
    }

    public void SetCurrentHp (int arg_currentHp)
    {
        currentHp = arg_currentHp;

        if (currentHp < 0)
        {
            currentHp = 0;
        }

        if (currentHp > maximumHp)
        {
            currentHp = maximumHp;
        }
    }

    public int GetMaximumSta()
    {
        return maximumSta;
    }

    public void SetMaximumSta(int arg_maximumSta)
    {
        maximumSta = arg_maximumSta;
    }

    public int GetCurrentSta()
    {
        return currentSta;
    }

    public void SetCurrentSta(int arg_currentSta)
    {
        currentSta = arg_currentSta;

        if (currentSta < 0)
        {
            currentSta = 0;
        }

        if (currentSta > maximumSta)
        {
            currentSta = maximumSta;
        }
    }

    public int GetAtk()
    {
        return currentAtk;
    }

    public void SetAtk(int arg_currentAtk)
    {
        currentAtk = arg_currentAtk;
    }

    public int GetSpd()
    {
        return currentSpd;
    }

    public void SetSpd(int arg_currentSpd)
    {
        currentSpd = arg_currentSpd;
    }
}
