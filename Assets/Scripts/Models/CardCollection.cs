using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardCollection
{
    private const int TOTAL_COLLECTION = 3;

    private static Card[] cardCollection = new Card[TOTAL_COLLECTION]
    {
        // CARD 0: (Temtem) Nessla
        new Card_Temtem(Resources.Load<Sprite>("Cards/Temtem_Nessla") as Sprite, "Nessla", 3, elementalTypesEnum.Electric, elementalTypesEnum.Water, 90, 30, 20, 40, traitsEnum.Electric_Synthesize, elementalTypesEnum.Crystal, elementalTypesEnum.Nature, elementalTypesEnum.Toxic, elementalTypesEnum.Fire, elementalTypesEnum.Water, elementalTypesEnum.Wind),
        
        // CARD 1: (Temtem) Barnshe
        new Card_Temtem(Resources.Load<Sprite>("Cards/Temtem_Barnshe") as Sprite, "Barnshe", 3, elementalTypesEnum.Mental, elementalTypesEnum.Wind, 80, 30, 30, 40, traitsEnum.Neutrality, elementalTypesEnum.Crystal, elementalTypesEnum.Digital, elementalTypesEnum.Electric, elementalTypesEnum.Earth, elementalTypesEnum.Melee, elementalTypesEnum.Wind),

        // CARD 2: (Temtem) Gyalis
        new Card_Temtem(Resources.Load<Sprite>("Cards/Temtem_Gyalis") as Sprite, "Gyalis", 4, elementalTypesEnum.Crystal, elementalTypesEnum.Melee, 110, 40, 40, 30, traitsEnum.Mirroring, elementalTypesEnum.Digital, elementalTypesEnum.Earth, elementalTypesEnum.Fire, elementalTypesEnum.Electric, elementalTypesEnum.Toxic, elementalTypesEnum.NULL)
    };

    public static Card[] GetCardCollection()
    {
        return cardCollection;
    }

    public static Card GetCard(int arg_cardIndex)
    {
        return cardCollection[arg_cardIndex];
    }
}
