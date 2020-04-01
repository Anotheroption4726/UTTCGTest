using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionScript : MonoBehaviour
{
    private const int TOTAL_COLLECTION = 3;
    private Card[] cardCollection = new Card[TOTAL_COLLECTION];
    [SerializeField] private Sprite[] cardDisplays = new Sprite[TOTAL_COLLECTION];

    void Awake()
    {
        // CARD 0: (Temtem) Nessla
        cardCollection[0] = new Card_Temtem(cardDisplays[0], "Nessla", 3, elementalTypesEnum.Electric, elementalTypesEnum.Water, 90, 30, 20, 40, traitsEnum.Electric_Synthesize, elementalTypesEnum.Crystal, elementalTypesEnum.Nature, elementalTypesEnum.Toxic, elementalTypesEnum.Fire, elementalTypesEnum.Water, elementalTypesEnum.Wind);

        // CARD 1: (Temtem) Barnshe
        cardCollection[1] = new Card_Temtem(cardDisplays[1], "Barnshe", 3, elementalTypesEnum.Mental, elementalTypesEnum.Wind, 80, 30, 30, 40, traitsEnum.Neutrality, elementalTypesEnum.Crystal, elementalTypesEnum.Digital, elementalTypesEnum.Electric, elementalTypesEnum.Earth, elementalTypesEnum.Melee, elementalTypesEnum.Wind);

        // CARD 2: (Temtem) Gyalis
        cardCollection[2] = new Card_Temtem(cardDisplays[2], "Gyalis", 4, elementalTypesEnum.Crystal, elementalTypesEnum.Melee, 110, 40, 40, 30, traitsEnum.Mirroring, elementalTypesEnum.Digital, elementalTypesEnum.Earth, elementalTypesEnum.Fire, elementalTypesEnum.Electric, elementalTypesEnum.Toxic, elementalTypesEnum.NULL);
    }

    public Card[] GetCardCollection()
    {
        return cardCollection;
    }
}
