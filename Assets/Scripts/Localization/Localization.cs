using System.Collections.Generic;
using UnityEngine;

public class Localization : MonoBehaviour
{
    public static string LANGUAGE_EN = "EN";
    public static string LANGUAGE_ES = "ES";
    public Dictionary<string, Dictionary<string, string>> Keys;
    [HideInInspector] public string Language = LANGUAGE_EN;

    #region Singleton
    public static Localization instance { get; private set; }
    void Awake()
    {
        instance = this;
        InitKeys();
    }
    #endregion
    
    public static string GetText(string key)
    {
        Debug.Log("Localization :: GetText " + key);
        string language = instance.Language;
        return instance.Keys[language][key];
    }

    void InitKeys()
    {
        Keys = new Dictionary<string, Dictionary<string, string>>();
        Keys[LANGUAGE_EN] = new Dictionary<string, string>();
        Keys[LANGUAGE_ES] = new Dictionary<string, string>();

        // English
        Keys[LANGUAGE_EN]["task1"] = "Prueba 1";
        Keys[LANGUAGE_EN]["task2"] = "Prueba 2";
        Keys[LANGUAGE_EN]["task3"] = "Prueba 3";
        

        // Spanish
        Keys[LANGUAGE_ES]["task1"] = "Test 1";
        Keys[LANGUAGE_ES]["task2"] = "Test 2";
        Keys[LANGUAGE_ES]["task3"] = "Test 3";
    }
}