using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameTemtemButtonScript : MonoBehaviour
{
    private Temtem temtem;
    private Image temtemDisplay;

    public Temtem GetTemtem ()
    {
        return temtem;
    }

    public void SetTemtem(Temtem arg_temtem)
    {
        temtem = arg_temtem;
        SetTemtemDisplay(temtem.GetCard().GetDisplay());
    }

    public Image GetTemtemDisplay()
    {
        return temtemDisplay;
    }

    public void SetTemtemDisplay(Sprite arg_temtemCardSprite)
    {
        temtemDisplay.sprite = arg_temtemCardSprite;
    }

    void Awake()
    {
        temtemDisplay = GetComponent<Image>();
    }
}
