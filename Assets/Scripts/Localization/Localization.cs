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
        
        Keys[LANGUAGE_ES]["task3-1"] = "Escapate! Busca una puerta para salir.";
        Keys[LANGUAGE_ES]["task3-2"] = "Tu teléfono está sonando, ve a la habitación a atenderlo!";
        Keys[LANGUAGE_ES]["task3-3"] = "Busca el teléfono que realmente está sonando.";
        Keys[LANGUAGE_ES]["task3-4"] = "Apaga el TV.";
        
        Keys[LANGUAGE_ES]["task4-1"] = "Ve a la cocina para hablar con tu pareja.";
        
        // English
        // TODO: ADD
    }
}