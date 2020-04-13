using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelectPrefabScript : MonoBehaviour
{
    private GameObject game;
    private GameScript gameScript;

    private Card card;
    private Card_Temtem cardTemtem;

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

        game = GameObject.Find("Game");
        gameScript = game.GetComponent<GameScript>();
    }

    public void SetCard(Card arg_card)
    {
        card = arg_card;

        if (card.GetUncoveredStatus())
        {
            cardDisplay.sprite = card.GetDisplay();
            selectCardButton.onClick.AddListener(SelectCardForDetailsListener);

            if (card.GetCardType() == cardTypesEnum.Temtem)
            {
                cardTemtem = (Card_Temtem)card;
            }
        }

        if (!card.GetUncoveredStatus())
        {
            cardDisplay.sprite = CardCollection.GetCardDisplayBack();
        }
    }

    public Card GetCard()
    {
        return card;
    }

    void SelectCardForDetailsListener()
    {
        Debug.Log("Card Info: " + card.GetInDeckId());

        gameScript.ToggleView(gameScript.GetBoardView(), false);
        gameScript.ToggleView(gameScript.GetSelectActionView(), false);
        gameScript.ToggleView(gameScript.GetCardDetailView(), true);

        cardDetailDisplay = GameObject.Find("CardDisplay").GetComponent<Image>();
        cardDetailNameDisplay = GameObject.Find("CardNameDisplay").GetComponent<Text>();
        cardDetailCreditsDisplay = GameObject.Find("CardCredits").GetComponent<Text>();

        if (gameScript.GetcurentBrowsingLocation() == browsingLocationEnum.Hand)
        {
            if (gameScript.GetcurentActionState() == actionStateEnum.Play)
            {
                SetupButtonView(0, "Close");
                gameScript.GetCardDetailButtonsTable()[0].onClick.AddListener(CloseCardDetailListener);

                SetupButtonView(1, "Play");
                gameScript.GetCardDetailButtonsTable()[1].onClick.AddListener(PlayTemtemCardListener);
            }

            if (gameScript.GetcurentActionState() == actionStateEnum.Select)
            {
                SetupButtonView(0, "Close");
                gameScript.GetCardDetailButtonsTable()[0].onClick.AddListener(CloseCardDetailListener);

                SetupButtonView(1, "Select");
                gameScript.GetCardDetailButtonsTable()[1].onClick.AddListener(SelectCardToPlayTemtemCardListener);
            }
        }

        if (gameScript.GetcurentBrowsingLocation() == browsingLocationEnum.TrashPile)
        {
            if (gameScript.GetcurentActionState() == actionStateEnum.Play)
            {
                SetupButtonView(0, "Close");
                gameScript.GetCardDetailButtonsTable()[0].onClick.AddListener(CloseCardDetailListener);
            }
        }


        cardDetailDisplay.sprite = card.GetDisplay() as Sprite;
        cardDetailNameDisplay.text = "<b>Temtem:</b> " + card.GetName();
        cardDetailCreditsDisplay.text = "<b>Credits:</b> " + card.GetCredits();

        if (card.GetCardType() == cardTypesEnum.Temtem)
        {
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

            cardTemtemDetailPansunsDisplay.text = "<b>Pansuns</b>: " + cardTemtem.GetPansuns();
            cardTemtemDetailType_1Display.text = "<b>Type 1:</b> " + cardTemtem.GetElementType_1();
            cardTemtemDetailType_2Display.text = "<b>Type 2:</b> " + cardTemtem.GetElementType_2();
            cardTemtemDetailHPDisplay.text = "<b>HP:</b> " + cardTemtem.GetHp();
            cardTemtemDetailWeaknessesDisplay.text = "<b>Weaknesses:</b> " + cardTemtem.GetWeakness_1() + ", " + cardTemtem.GetWeakness_2() + ", " + cardTemtem.GetWeakness_3();
            cardTemtemDetailResistancesDisplay.text = "<b>Weaknesses:</b> " + cardTemtem.GetResistance_1() + ", " + cardTemtem.GetResistance_2() + ", " + cardTemtem.GetResistance_3();
            cardTemtemDetailATKDisplay.text = "<b>ATK:</b> " + cardTemtem.GetAtk();
            cardTemtemDetailSPDDisplay.text = "<b>SPD:</b> " + cardTemtem.GetSpd();
            cardTemtemDetailSTADisplay.text = "<b>STA:</b> " + cardTemtem.GetSta();
            cardTemtemDetailTraitDisplay.text = cardTemtem.GetTraitText();
        }
    }

    void SetupButtonView(int arg_buttonIndex, string arg_buttonText)
    {
        gameScript.ToggleView(gameScript.GetCardDetailViewButtonsTable()[arg_buttonIndex], true);
        gameScript.GetCardDetailButtonsTable()[arg_buttonIndex].onClick.RemoveAllListeners();
        gameScript.GetCardDetailButtonsTable()[arg_buttonIndex].GetComponentInChildren<Text>().text = arg_buttonText;
    }

    void CloseCardDetailListener()
    {
        gameScript.ClearCardButtonsViewDisplay();
        gameScript.ToggleView(gameScript.GetCardDetailView(), false);

        if (gameScript.GetcurentActionState() == actionStateEnum.Play)
        {
            gameScript.ToggleView(gameScript.GetBoardView(), true);
        }

        if (gameScript.GetcurentActionState() == actionStateEnum.Select)
        {
            gameScript.ToggleView(gameScript.GetSelectActionView(), true);
        }
    }

    void PlayTemtemCardListener()
    {
        gameScript.SetcurentBrowsingLocation(browsingLocationEnum.Hand);
        gameScript.SetCurentActionState(actionStateEnum.Select);

        gameScript.ClearCardButtonsViewDisplay();
        gameScript.ToggleView(gameScript.GetCardDetailView(), false);
        gameScript.ToggleView(gameScript.GetSelectActionView(), true);

        gameScript.AddcardToSelectionList(card.GetInDeckId());
        gameScript.SetCardSelectionTotalCards(cardTemtem.GetPansuns());
        gameScript.SetCardSelectionCurrentCards(0);

        gameScript.DisplayCardListSelectModeList(gameScript.GetHandTamer_1());
        gameScript.GetGamePrompt().text = "Select " + gameScript.GetCardSelectionTotalCards() + " cards to discard from your Hand";
        Debug.Log("Card played: " + card.GetInDeckId());
    }

    void SelectCardToPlayTemtemCardListener()
    {
        SelectCard(gameScript.GetHandTamer_1());

        gameScript.GetGamePrompt().text = "Select " + gameScript.GetCardSelectionTotalCards() + " cards to discard from your Hand";
        Debug.Log("Card Selected: " + card.GetInDeckId());
    }

    void SelectCard(List<Card> arg_cardList)
    {
        gameScript.ClearCardButtonsViewDisplay();
        gameScript.ToggleView(gameScript.GetCardDetailView(), false);
        gameScript.ToggleView(gameScript.GetSelectActionView(), true);

        gameScript.AddcardToSelectionList(card.GetInDeckId());
        gameScript.DisplayCardListSelectModeList(arg_cardList);
    }

    void TEST_DiscardCardFromHand()
    {
        gameScript.ClearCardButtonsViewDisplay();
        gameScript.MoveSpecificCardFromListToOtherList(gameScript.GetHandTamer_1(), card.GetInDeckId(), gameScript.GetTrashPileTamer_1());
        gameScript.SetcurentBrowsingLocation(browsingLocationEnum.Hand);
    }
}
