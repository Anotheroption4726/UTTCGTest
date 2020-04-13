using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : MonoBehaviour
{
    [SerializeField] private GameObject logText;
    private List<GameObject> logTextList = new List<GameObject>();

    public void AddLogText(string arg_newtext)
    {
        if (logTextList.Count == 50)
        {
            GameObject loc_tempItem = logTextList[0];
            Destroy(loc_tempItem.gameObject);
            logTextList.Remove(loc_tempItem);
        }

        GameObject loc_newText = Instantiate(logText) as GameObject;
        loc_newText.SetActive(true);

        loc_newText.GetComponent<LogTextItemScript>().SetText(arg_newtext);
        loc_newText.transform.SetParent(logText.transform.parent, false);

        logTextList.Add(loc_newText.gameObject);
    }
}
