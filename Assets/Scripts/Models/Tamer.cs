using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tamer
{
    private string name;
    private bool advantage;

    private Temtem[] inGameTemtems = new Temtem[6];

    private List<Card> backpack;
    private List<Card> trashPile = new List<Card>();
    private List<Card> hand = new List<Card>();

    public Tamer(string arg_tamerName, List<Card> arg_tamerBackpack)
    {
        name = arg_tamerName;
        backpack = arg_tamerBackpack;
    }

    public string GetName()
    {
        return name;
    }

    public void SetName(string arg_tamerName)
    {
        name = arg_tamerName;
    }

    public bool GetAdvantage()
    {
        return advantage;
    }

    public void SetAdvantage(bool arg_tamerAdvantage)
    {
        advantage = arg_tamerAdvantage;
    }

    public void ToggleAdvantage()
    {
        advantage = !advantage;
    }

    public Temtem[] GetInGameTemtems()
    {
        return inGameTemtems;
    }

    public void SetInGameTemtems(Temtem[] arg_temtemsArray)
    {
        inGameTemtems = arg_temtemsArray;
    }

    public void AddTemtemToGame(Temtem arg_temtem)
    {
        for (int i = 0; i < inGameTemtems.Length; i++)
        {
            if (inGameTemtems[i] == null)
            {
                inGameTemtems[i] = arg_temtem;
                inGameTemtems[i].SetInGameIndex(i);
                break;
            }
        }
    }

    public void RemoveTemtemFromGame()
    {
        
    }

    public List<Card> GetBackpack()
    {
        return backpack;
    }

    public List<Card> GetTrashPile()
    {
        return trashPile;
    }

    public List<Card> GetHand()
    {
        return hand;
    }
}
