using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private Text taskText;

    public void SetTaskText(string text)
    {
        taskText.text = text;
    }
}
