using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text taskText;
    [SerializeField] private Text subtitleText;
    [SerializeField] private Text hintText;

    public void SetTaskText(string text)
    {
        taskText.transform.parent.gameObject.SetActive(text?.Length > 0);
        taskText.text = text;
    }
    
    public void SetSubtitleText(string text)
    {
        subtitleText.transform.parent.gameObject.SetActive(text?.Length > 0);
        subtitleText.text = text;
    }
    
    public void SetHintText(string text)
    {
        hintText.transform.parent.gameObject.SetActive(text?.Length > 0);
        hintText.text = text;
    }
}
