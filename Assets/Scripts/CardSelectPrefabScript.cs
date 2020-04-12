using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelectPrefabScript : MonoBehaviour
{
    private GameObject game;
    private GameScript gameScript;
    private GameObject canvas;
    private GameObject outOfCanvasGameObject;
    private GameObject BoardView;
    private GameObject cardDetailView;
    private GameObject CardDetailViewButton_0;
    private GameObject CardDetailViewButton_1;
    //private List<GameObject> CardDetailViewButtonsTable = new List<GameObject>();

    private Card card;
    private Card_Temtem cardTemtem;

    private Image cardDisplay;
    private Button selectCardButton;


    private Button CardDetailButton_0;
    private Button CardDetailButton_1;

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
        canvas = GameObject.Find("Canvas");
        outOfCanvasGameObject = GameObject.Find("OutOfCanvas");
        BoardView = GameObject.Find("BoardView");
        cardDetailView = GameObject.Find("CardDetailView");
    }

    public void SetCard(Card arg_card)
    {
        card = arg_card;

        if (card.GetUncoveredStatus())
        {
            cardDisplay.sprite = card.GetDisplay();
            selectCardButton.onClick.AddListener(SelectCardForDetails);

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

    void SelectCardForDetails()
    {
        Debug.Log("Card Info: " + card.GetInDeckId());

        cardDetailView.transform.SetParent(canvas.transform, true);
        BoardView.transform.SetParent(outOfCanvasGameObject.transform, true);

        cardDetailDisplay = GameObject.Find("CardDisplay").GetComponent<Image>();
        cardDetailNameDisplay = GameObject.Find("CardNameDisplay").GetComponent<Text>();
        cardDetailCreditsDisplay = GameObject.Find("CardCredits").GetComponent<Text>();

        if (gameScript.GetcurentBrowsingLocation() == browsingLocationEnum.Hand)
        {
            if (gameScript.GetcurentActionState() == actionStateEnum.Play)
            {
                CardDetailViewButton_0 = GameObject.Find("CardDetailButton_0");
                CardDetailViewButton_0.transform.SetParent(canvas.transform, true);
                CardDetailButton_0 = CardDetailViewButton_0.GetComponent<Button>();
                CardDetailButton_0.onClick.RemoveAllListeners();
                CardDetailButton_0.GetComponentInChildren<Text>().text = "Close";
                CardDetailButton_0.onClick.AddListener(CloseCardDetailListener);

                CardDetailViewButton_1 = GameObject.Find("CardDetailButton_1");
                CardDetailViewButton_1.transform.SetParent(canvas.transform, true);
                CardDetailButton_1 = CardDetailViewButton_1.GetComponent<Button>();
                CardDetailButton_1.onClick.RemoveAllListeners();
                CardDetailButton_1.GetComponentInChildren<Text>().text = "Play";
                CardDetailButton_1.onClick.AddListener(PlayTemtemCardListener);
            }

            if (gameScript.GetcurentActionState() == actionStateEnum.Select)
            {
                CardDetailViewButton_0 = GameObject.Find("CardDetailButton_0");
                CardDetailViewButton_0.transform.SetParent(canvas.transform, true);
                CardDetailButton_0 = CardDetailViewButton_0.GetComponent<Button>();
                CardDetailButton_0.onClick.RemoveAllListeners();
                CardDetailButton_0.GetComponentInChildren<Text>().text = "Cancel";
                CardDetailButton_0.onClick.AddListener(CancelActionSelectionListener);
                
                CardDetailViewButton_1 = GameObject.Find("CardDetailButton_1");
                CardDetailViewButton_1.transform.SetParent(canvas.transform, true);
                CardDetailButton_1 = CardDetailViewButton_1.GetComponent<Button>();
                CardDetailButton_1.onClick.RemoveAllListeners();
                CardDetailButton_1.GetComponentInChildren<Text>().text = "Select";
                CardDetailButton_1.onClick.AddListener(SelectCardListener);
            }
        }

        if (gameScript.GetcurentBrowsingLocation() == browsingLocationEnum.TrashPile)
        {
            if (gameScript.GetcurentActionState() == actionStateEnum.Play)
            {
                CardDetailViewButton_0 = GameObject.Find("CardDetailButton_0");
                CardDetailViewButton_0.transform.SetParent(canvas.transform, true);
                CardDetailButton_0 = CardDetailViewButton_0.GetComponent<Button>();
                CardDetailButton_0.onClick.RemoveAllListeners();
                CardDetailButton_0.GetComponentInChildren<Text>().text = "Close";
                CardDetailButton_0.onClick.AddListener(CloseCardDetailListener);
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

    void SetupButtonView(GameObject arg_cardDetailViewButton, Button arg_cardDetailButton, string arg_buttonText)
    {
        
    }

    void CloseCardDetailListener()
    {
        ClearCardButtonsDisplay();
        
        cardDetailView.transform.SetParent(outOfCanvasGameObject.transform, true);
        BoardView.transform.SetParent(canvas.transform, true);

        gameScript.SetcurentBrowsingLocation(browsingLocationEnum.Hand);
    }

    void CancelActionSelectionListener()
    {
        ClearCardButtonsDisplay();

        cardDetailView.transform.SetParent(outOfCanvasGameObject.transform, true);
        BoardView.transform.SetParent(canvas.transform, true);

        gameScript.SetcurentBrowsingLocation(browsingLocationEnum.Hand);
        gameScript.SetCurentActionState(actionStateEnum.Play);
    }

    void PlayTemtemCardListener()
    {
        Debug.Log("Card played: " + card.GetInDeckId());

        ClearCardButtonsDisplay();

        gameScript.SetcurentBrowsingLocation(browsingLocationEnum.Hand);
        gameScript.SetCurentActionState(actionStateEnum.Select);
    }

    void SelectCardListener()
    {
        Debug.Log("Card Selected: " + card.GetInDeckId());
    }

    void ClearCardButtonsDisplay()
    {
        CardDetailViewButton_0 = GameObject.Find("CardDetailButton_0");
        CardDetailViewButton_0.transform.SetParent(outOfCanvasGameObject.transform, true);

        CardDetailViewButton_1 = GameObject.Find("CardDetailButton_1");
        CardDetailViewButton_1.transform.SetParent(outOfCanvasGameObject.transform, true);
    }

    void TEST_DiscardCardFromHand()
    {
        ClearCardButtonsDisplay();
        gameScript.MoveSpecificCardFromListToOtherList(gameScript.GetHandTamer_1(), card.GetInDeckId(), gameScript.GetTrashPileTamer_1());
        gameScript.SetcurentBrowsingLocation(browsingLocationEnum.Hand);
    }
}
