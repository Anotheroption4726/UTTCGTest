using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogTextItemScript : MonoBehaviour
{
    public void SetText(string arg_text)
    {
        GetComponent<Text>().text = arg_text;
    }
}
