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

    void Awake()
    {
        cardDisplay = GetComponent<Image>();
        selectCardButton = GetComponent<Button>();
        selectCardButton.onClick.AddListener(SelectCardForDetails);

        cardDetailDisplay = GameObject.Find("CardDisplay");
        cardDetailDisplay_image = cardDetailDisplay.GetComponent<Image>();

        cardDetailNameDisplay = GameObject.Find("CardNameDisplay");
        cardDetailNameDisplay_content = cardDetailNameDisplay.GetComponent<Text>();
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
        //cardContentImgDisplay.sprite = card.GetDisplay() as Sprite;
        //cardContentImgDisplay.sprite = Resources.Load<Sprite>("Cards/Temtem_Barnshe");
        cardDetailDisplay_image.sprite = card.GetDisplay() as Sprite;
        cardDetailNameDisplay_content.text = card.GetName();
    }
}
