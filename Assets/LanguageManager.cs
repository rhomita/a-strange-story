using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LanguageManager : MonoBehaviour
{
    #region Singleton
    public static LanguageManager instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public Language Language { get; private set; }
    public void SetLanguage(string language)
    {
        Language = (Language) Enum.Parse(typeof(Language), language);
    }
}

public enum Language
{
    ES,
    EN
}