using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Temtem : Card
{
    private int pansuns;

    private elementTypesEnum type_1;
    private elementTypesEnum type_2;

    private int hp;
    private int atk;
    private int spd;
    private int sta;

    private traitsEnum trait;
    private string traitText;

    private elementTypesEnum weakness_1;
    private elementTypesEnum weakness_2;
    private elementTypesEnum weakness_3;

    private elementTypesEnum resistance_1;
    private elementTypesEnum resistance_2;
    private elementTypesEnum resistance_3;

    public Card_Temtem(
        Sprite arg_display,
        string arg_name,
        string arg_credits,
        cardSetEnum arg_cardSet,
        cardRarityEnum arg_cardRarity,
        int arg_pansuns,
        elementTypesEnum arg_type_1,
        elementTypesEnum arg_type_2,
        int arg_hp,
        int arg_atk,
        int arg_spd,
        int arg_sta,
        traitsEnum arg_trait,
        string arg_traitText,
        elementTypesEnum arg_weakness_1,
        elementTypesEnum arg_weakness_2,
        elementTypesEnum arg_weakness_3,
        elementTypesEnum arg_resistance_1,
        elementTypesEnum arg_resistance_2,
        elementTypesEnum arg_resistance_3
    )
    {
        SetCardType(cardTypesEnum.Temtem);
        SetDisplay(arg_display);
        SetName(arg_name);
        SetCredits(arg_credits);
        SetCardSet(arg_cardSet);
        SetCardRarity(arg_cardRarity);
        pansuns = arg_pansuns;
        type_1 = arg_type_1;
        type_2 = arg_type_2;
        hp = arg_hp;
        atk = arg_atk;
        spd = arg_spd;
        sta = arg_sta;
        trait = arg_trait;
        traitText = arg_traitText;
        weakness_1 = arg_weakness_1;
        weakness_2 = arg_weakness_2;
        weakness_3 = arg_weakness_3;
        resistance_1 = arg_resistance_1;
        resistance_2 = arg_resistance_2;
        resistance_3 = arg_resistance_3;
    }

    public virtual int GetPansuns()
    {
        return pansuns;
    }

    public elementTypesEnum GetType_1()
    {
        return type_1;
    }

    public elementTypesEnum GetType_2()
    {
        return type_2;
    }

    public int GetHp()
    {
        return hp;
    }

    public int GetAtk()
    {
        return atk;
    }

    public int GetSpd()
    {
        return spd;
    }

    public int GetSta()
    {
        return sta;
    }

    public traitsEnum GetTrait()
    {
        return trait;
    }

    public string GetTraitText()
    {
        return traitText;
    }

    public elementTypesEnum GetWeakness_1()
    {
        return weakness_1;
    }

    public elementTypesEnum GetWeakness_2()
    {
        return weakness_2;
    }

    public elementTypesEnum GetWeakness_3()
    {
        return weakness_3;
    }

    public elementTypesEnum GetResistance_1()
    {
        return resistance_1;
    }

    public elementTypesEnum GetResistance_2()
    {
        return resistance_2;
    }

    public elementTypesEnum GetResistance_3()
    {
        return resistance_3;
    }

}
