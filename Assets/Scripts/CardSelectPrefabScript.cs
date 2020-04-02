using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelectPrefabScript : MonoBehaviour
{
    private Card card;

    private Image cardDisplay;
    private Button selectCardButton;

    private GameObject cardDetailDisplay;
    private Image cardDetailDisplay_image;

    private GameObject cardDetailNameDisplay;
    private Text cardDetailNameDisplay_content;

    private GameObject cardDetailPansunsDisplay;
    private Text cardDetailPansunsDisplay_content;

    void Awake()
    {
        cardDisplay = GetComponent<Image>();
        selectCardButton = GetComponent<Button>();
        selectCardButton.onClick.AddListener(SelectCardForDetails);

        cardDetailDisplay = GameObject.Find("CardDisplay");
        cardDetailDisplay_image = cardDetailDisplay.GetComponent<Image>();

        cardDetailNameDisplay = GameObject.Find("CardNameDisplay");
        cardDetailNameDisplay_content = cardDetailNameDisplay.GetComponent<Text>();

        cardDetailPansunsDisplay = GameObject.Find("CardPansunsDisplay");
        cardDetailPansunsDisplay_content = cardDetailNameDisplay.GetComponent<Text>();
    }

    public void SetCard(Card arg_card)
    {
        card = arg_card;
        cardDisplay.sprite = card.GetDisplay();
    }

    public Card GetCard()
    {
        return card;
    }

    void SelectCardForDetails()
    {
        cardDetailDisplay_image.sprite = card.GetDisplay() as Sprite;
        cardDetailNameDisplay_content.text = "Temtem: " + card.GetName();
        //cardDetailPansunsDisplay_content.text = "Pansuns: " + card.GetCost();
    }
}
