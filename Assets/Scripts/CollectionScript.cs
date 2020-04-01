using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionScript : MonoBehaviour
{
    private const int TOTAL_COLLECTION = 3;
    [SerializeField] private Sprite[] cardDisplays = new Sprite[TOTAL_COLLECTION];
    private Card[] cardCollection = new Card[TOTAL_COLLECTION];

    void Awake()
    {
        // CARD 0: (Temtem) Nessla
        cardCollection[0] = new Card_Temtem(cardDisplays[0], "Nessla", 3, typesEnum.Electric, typesEnum.Water, 90, 30, 20, 40, traitsEnum.Electric_Synthesize, typesEnum.Crystal, typesEnum.Nature, typesEnum.Toxic, typesEnum.Fire, typesEnum.Water, typesEnum.Wind);

        // CARD 1: (Temtem) Barnshe
        cardCollection[1] = new Card_Temtem(cardDisplays[1], "Barnshe", 3, typesEnum.Mental, typesEnum.Wind, 80, 30, 30, 40, traitsEnum.Neutrality, typesEnum.Crystal, typesEnum.Digital, typesEnum.Electric, typesEnum.Earth, typesEnum.Melee, typesEnum.Wind);

        // CARD 2: (Temtem) Gyalis
        cardCollection[2] = new Card_Temtem(cardDisplays[2], "Gyalis", 4, typesEnum.Crystal, typesEnum.Melee, 110, 40, 40, 30, traitsEnum.Mirroring, typesEnum.Digital, typesEnum.Earth, typesEnum.Fire, typesEnum.Electric, typesEnum.Toxic, typesEnum.NULL);
    }

    public Card[] GetCardCollection()
    {
        return cardCollection;
    }
}
