using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelectPrefabScript : MonoBehaviour
{
    private Card card;
    Card_Temtem cardTemtem;

    private Image cardDisplay;
    private Button selectCardButton;

    private Image cardDetailDisplay;
    private Text cardDetailNameDisplay;

    private Text cardTemtemDetailPansunsDisplay;
    private Text cardTemtemDetailHPDisplay;
    private Text cardTemtemDetailATKDisplay;
    private Text cardTemtemDetailSPDDisplay;
    private Text cardTemtemDetailSTADisplay;

    void Awake()
    {
        cardDisplay = GetComponent<Image>();
        selectCardButton = GetComponent<Button>();
        selectCardButton.onClick.AddListener(SelectCardForDetails);

        cardDetailDisplay = GameObject.Find("CardDisplay").GetComponent<Image>();
        cardDetailNameDisplay = GameObject.Find("CardNameDisplay").GetComponent<Text>();
    }

    public void SetCard(Card arg_card)
    {
        card = arg_card;
        cardDisplay.sprite = card.GetDisplay();

        if (card.GetCardType() == cardTypesEnum.Temtem)
        {
            cardTemtem = (Card_Temtem)card;
            cardTemtemDetailPansunsDisplay = GameObject.Find("CardPansunsDisplay").GetComponent<Text>();
        }
    }

    public Card GetCard()
    {
        return card;
    }

    void SelectCardForDetails()
    {
        cardDetailDisplay.sprite = card.GetDisplay() as Sprite;
        cardDetailNameDisplay.text = "Temtem: " + card.GetName();

        if (card.GetCardType() == cardTypesEnum.Temtem)
        {
            cardTemtemDetailPansunsDisplay.text = "Pansuns: " + cardTemtem.GetPansuns();
        }
    }
}
