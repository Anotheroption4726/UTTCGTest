using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Temtem
{
    private Sprite display;

    private string name;
    private string cost;

    private typesEnum type_1;
    private typesEnum type_2;

    private int hp;
    private int atk;
    private int spd;
    private int sta;

    private traitsEnum trait;

    private typesEnum weakness_1;
    private typesEnum weakness_2;
    private typesEnum weakness_3;

    private typesEnum resistance_1;
    private typesEnum resistance_2;
    private typesEnum resistance_3;

    public Card_Temtem(Sprite arg_display, string arg_name, string arg_cost, typesEnum arg_type_1, typesEnum arg_type_2, int arg_hp, int arg_atk, int arg_spd, int arg_sta, traitsEnum arg_trait, typesEnum arg_weakness_1, typesEnum arg_weakness_2, typesEnum arg_weakness_3, typesEnum arg_resistance_1, typesEnum arg_resistance_2, typesEnum arg_resistance_3)
    {
        display = arg_display;
        name = arg_name;
        cost = arg_cost;
        type_1 = arg_type_1;
        type_2 = arg_type_2;
        hp = arg_hp;
        atk = arg_atk;
        spd = arg_spd;
        sta = arg_sta;
        trait = arg_trait;
        weakness_1 = arg_weakness_1;
        weakness_2 = arg_weakness_2;
        weakness_3 = arg_weakness_3;
        resistance_1 = arg_resistance_1;
        resistance_2 = arg_resistance_2;
        resistance_3 = arg_resistance_3;
    }

    public Sprite GetDisplay()
    {
        return display;
    }

    public string GetName()
    {
        return name;
    }

    public string GetCost()
    {
        return cost;
    }

    public typesEnum GetType_1()
    {
        return type_1;
    }

    public typesEnum GetType_2()
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

    public typesEnum GetWeakness_1()
    {
        return weakness_1;
    }

    public typesEnum GetWeakness_2()
    {
        return weakness_2;
    }

    public typesEnum GetWeakness_3()
    {
        return weakness_3;
    }

    public typesEnum GetResistance_1()
    {
        return resistance_1;
    }

    public typesEnum GetResistance_2()
    {
        return resistance_2;
    }

    public typesEnum GetResistance_3()
    {
        return resistance_3;
    }

}
