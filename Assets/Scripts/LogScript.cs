using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : MonoBehaviour
{
    [SerializeField] private GameObject logText;
    [SerializeField] private GameObject logContentView;
    private List<GameObject> logTextList = new List<GameObject>();

    public void AddLogText(string arg_newtext, Color arg_color)
    {
        if (logTextList.Count == 50)
        {
            GameObject loc_tempItem = logTextList[0];
            Destroy(loc_tempItem.gameObject);
            logTextList.Remove(loc_tempItem);
        }

        GameObject loc_newLogText = Instantiate(logText) as GameObject;
        loc_newLogText.SetActive(true);

        loc_newLogText.GetComponent<LogTextPrefabScript>().SetText(arg_newtext, arg_color);
        loc_newLogText.transform.SetParent(logContentView.transform, false);

        logTextList.Add(loc_newLogText.gameObject);
    }
}
