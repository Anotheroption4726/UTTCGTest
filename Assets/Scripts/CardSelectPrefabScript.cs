using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelectPrefabScript : MonoBehaviour
{
    private Card card;
    private Image cardDisplay;
    private Button selectCardButton;

    [SerializeField] private GameObject cardContentDisplay;
    private Image cardContentImgDisplay;
    private Text cardContentNameDisplay;

    void Awake()
    {
        cardDisplay = GetComponent<Image>();
        selectCardButton = GetComponent<Button>();
        selectCardButton.onClick.AddListener(SelectCard);

        cardContentDisplay = GameObject.Find("CardNameDisplay");
        cardContentImgDisplay = cardContentDisplay.GetComponent<Image>();
        cardContentNameDisplay = cardContentDisplay.GetComponent<Text>();
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

    void SelectCard()
    {
        cardContentImgDisplay.sprite = card.GetDisplay();
        cardContentNameDisplay.text = card.GetName();
    }
}
