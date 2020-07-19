using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Localization : MonoBehaviour
{
    public static string LANGUAGE_EN = "EN";
    public static string LANGUAGE_ES = "ES";
    public Dictionary<string, Dictionary<string, string>> Keys;
    [HideInInspector] public string Language = LANGUAGE_ES;

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
        if (!instance.Keys[language].ContainsKey(key)) return $"[{key}][{language}] Key not found";
        return instance.Keys[language][key];
    }

    void InitKeys()
    {
        Keys = new Dictionary<string, Dictionary<string, string>>();
        Keys[LANGUAGE_EN] = new Dictionary<string, string>();
        Keys[LANGUAGE_ES] = new Dictionary<string, string>();

        

        // Spanish
        Keys[LANGUAGE_ES]["task1-1"] = "Acomodar la habitación.";
        Keys[LANGUAGE_ES]["task2-1"] = "Recoge la ropa sucia en tu habitación.";
        Keys[LANGUAGE_ES]["task2-2"] = "Lleva la ropa sucia a la lavadora.";
        
        // English
        // TODO: ADD
    }
}