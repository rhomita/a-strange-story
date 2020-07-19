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
        // Quests and tasks
        Keys[LANGUAGE_ES]["task1-1"] = "Acomoda la habitación.";
        
        Keys[LANGUAGE_ES]["task2-1"] = "Recoge la ropa sucia en tu habitación.";
        Keys[LANGUAGE_ES]["task2-2"] = "Lleva la ropa sucia al lavarropas.";
        
        Keys[LANGUAGE_ES]["task3-1"] = "Escapate! Busca una puerta para salir.";
        Keys[LANGUAGE_ES]["task3-2"] = "Tu teléfono está sonando, ve a la habitación para atenderlo!";
        Keys[LANGUAGE_ES]["task3-3"] = "Busca el teléfono que realmente está sonando.";
        Keys[LANGUAGE_ES]["task3-4"] = "";
        Keys[LANGUAGE_ES]["task3-5"] = "Apaga el TV.";
        
        Keys[LANGUAGE_ES]["task4-1"] = "Ve a la cocina para hablar con tu pareja.";
        
        Keys[LANGUAGE_ES]["hint-generic"] = "Presiona 'e' para interactuar.";
        Keys[LANGUAGE_ES]["hint-1"] = "Presiona 'e' para tender la cama.";
        Keys[LANGUAGE_ES]["hint-2"] = "Presiona 'e' para cerrar el cajón.";
        Keys[LANGUAGE_ES]["hint-3"] = "Presiona 'e' para acomodar el cuadro.";
        Keys[LANGUAGE_ES]["hint-4"] = "Presiona 'e' para recoger la ropa sucia.";
        Keys[LANGUAGE_ES]["hint-5"] = "Presiona 'e' para tirar la ropa sucia en el lavarropas.";
        Keys[LANGUAGE_ES]["hint-6"] = "Presiona 'e' para escaparse por la puerta.";
        Keys[LANGUAGE_ES]["hint-7"] = "Presiona 'e' para atender el teléfono.";
        Keys[LANGUAGE_ES]["hint-8"] = "Presiona 'e' para apagar el televisor.";
        
        // UI Info
        Keys[LANGUAGE_ES]["info.restart"] = "Presiona 'R' para reiniciar.";
        
        // Subtitles
        Keys[LANGUAGE_ES]["voice-1"] = "Voz: MATEO! MATEOOO! Despiertate ya! Todo el día durmiendo!";
        Keys[LANGUAGE_ES]["voice-2"] = "Voz: Levantate y ordena ese cuarto mugroso! Tiende la cama y pon un poco de orden, madre mia!";
        Keys[LANGUAGE_ES]["voice-3"] = "Voz: Y no te olvides de llevar esa ropa toda sucia al lavarropas!";
        Keys[LANGUAGE_ES]["voice-4"] = "Voz: MATEEEEEEO, el televisor está prendido, apágalo por favor!";
        Keys[LANGUAGE_ES]["voice-5"] = "Voz: Tenemos que hablar, ven a la cocina. YA!";
        Keys[LANGUAGE_ES]["voice-6"] = "Heladera: No puede ser que estés todo el día jugando a los jueguitos de computadora. ¡Tienes que ponerte las pilas y hacer algo!";
        
        Keys[LANGUAGE_ES]["m-voice-1"] = "Lavarropas: ¡Qué pasa acá! ¿Por qué están todos gritando?";
        Keys[LANGUAGE_ES]["m-voice-2"] = "Lavarropas: Pero... tu también eres una heladera!";
        
        Keys[LANGUAGE_ES]["p-voice-1"] = "Mateo: Madre mía, esa ropa estaba llena de sangre, tengo que irme de aquí.";
        Keys[LANGUAGE_ES]["p-voice-2"] = "Mateo: Maldición, esa puerta está cerrada.";
        Keys[LANGUAGE_ES]["p-voice-3"] = "Mateo: Estaba muy seguro de que este era el teléfono que sonaba.";
        Keys[LANGUAGE_ES]["p-voice-4"] = "Mateo: ¿Cómo es que este teléfono funciona? Ni siquiera está conectado.";
        Keys[LANGUAGE_ES]["p-voice-5"] = "Mateo: Es la última vez que me caso con una heladera!";
        Keys[LANGUAGE_ES]["p-voice-6"] = "Mateo: Noooooooo!!!";
        
        Keys[LANGUAGE_ES]["menu-play-button"] = "Empezar";
        Keys[LANGUAGE_ES]["menu-exit-button"] = "Salir";

        // English
        // TODO: ADD
    }
}