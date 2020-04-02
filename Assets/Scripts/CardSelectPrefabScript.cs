using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelectPrefabScript : MonoBehaviour
{
    private Card card;
    Card_Temtem cardTemtem;

    [SerializeField] private GameObject cardDetailView;

    private Image cardDisplay;
    private Button selectCardButton;

    private Image cardDetailDisplay;
    private Text cardDetailNameDisplay;
    private Text cardDetailCreditsDisplay;

    private Text cardTemtemDetailPansunsDisplay;
    private Text cardTemtemDetailType_1Display;
    private Text cardTemtemDetailType_2Display;
    private Text cardTemtemDetailHPDisplay;
    private Text cardTemtemDetailWeaknessesDisplay;
    private Text cardTemtemDetailResistancesDisplay;
    private Text cardTemtemDetailATKDisplay;
    private Text cardTemtemDetailSPDDisplay;
    private Text cardTemtemDetailSTADisplay;
    private Text cardTemtemDetailTraitDisplay;

    void Awake()
    {
        cardDisplay = GetComponent<Image>();
        selectCardButton = GetComponent<Button>();
        selectCardButton.onClick.AddListener(SelectCardForDetails);

        cardDetailView = GameObject.Find("CardDetailView");

        cardDetailDisplay = GameObject.Find("CardDisplay").GetComponent<Image>();
        cardDetailNameDisplay = GameObject.Find("CardNameDisplay").GetComponent<Text>();
        cardDetailCreditsDisplay = GameObject.Find("CardCredits").GetComponent<Text>();
    }

    public void SetCard(Card arg_card)
    {
        card = arg_card;
        cardDisplay.sprite = card.GetDisplay();

        if (card.GetCardType() == cardTypesEnum.Temtem)
        {
            cardTemtem = (Card_Temtem)card;
            cardTemtemDetailPansunsDisplay = GameObject.Find("CardPansunsDisplay").GetComponent<Text>();
            cardTemtemDetailType_1Display = GameObject.Find("CardType_1Display").GetComponent<Text>();
            cardTemtemDetailType_2Display = GameObject.Find("CardType_2Display").GetComponent<Text>();
            cardTemtemDetailHPDisplay = GameObject.Find("CardHPDisplay").GetComponent<Text>();
            cardTemtemDetailWeaknessesDisplay = GameObject.Find("CardWeaknessesDisplay").GetComponent<Text>();
            cardTemtemDetailResistancesDisplay = GameObject.Find("CardResistancesDisplay").GetComponent<Text>();
            cardTemtemDetailATKDisplay = GameObject.Find("CardATKDisplay").GetComponent<Text>();
            cardTemtemDetailSPDDisplay = GameObject.Find("CardSPDDisplay").GetComponent<Text>();
            cardTemtemDetailSTADisplay = GameObject.Find("CardSTADisplay").GetComponent<Text>();
            cardTemtemDetailTraitDisplay = GameObject.Find("CardTraitDisplay").GetComponent<Text>();
}
    }

    public Card GetCard()
    {
        return card;
    }

    void SelectCardForDetails()
    {
        cardDetailView.SetActive(true);

        cardDetailDisplay.sprite = card.GetDisplay() as Sprite;
        cardDetailNameDisplay.text = "<b>Temtem:</b> " + card.GetName();
        cardDetailCreditsDisplay.text = "<b>Credits:</b> " + card.GetCredits();

        if (card.GetCardType() == cardTypesEnum.Temtem)
        {
            cardTemtemDetailPansunsDisplay.text = "<b>Pansuns</b>: " + cardTemtem.GetPansuns();
            cardTemtemDetailType_1Display.text = "<b>Type 1:</b> " + cardTemtem.GetType_1();
            cardTemtemDetailType_2Display.text = "<b>Type 2:</b> " + cardTemtem.GetType_2();
            cardTemtemDetailHPDisplay.text = "<b>HP:</b> " + cardTemtem.GetHp();
            cardTemtemDetailWeaknessesDisplay.text = "<b>Weaknesses:</b> " + cardTemtem.GetWeakness_1() + ", " + cardTemtem.GetWeakness_2() + ", " + cardTemtem.GetWeakness_3();
            cardTemtemDetailResistancesDisplay.text = "<b>Weaknesses:</b> " + cardTemtem.GetResistance_1() + ", " + cardTemtem.GetResistance_2() + ", " + cardTemtem.GetResistance_3();
            cardTemtemDetailATKDisplay.text = "<b>ATK:</b> " + cardTemtem.GetAtk();
            cardTemtemDetailSPDDisplay.text = "<b>SPD:</b> " + cardTemtem.GetSpd();
            cardTemtemDetailSTADisplay.text = "<b>STA:</b> " + cardTemtem.GetSta();
            cardTemtemDetailTraitDisplay.text = cardTemtem.GetTraitText();
        }
    }
}
