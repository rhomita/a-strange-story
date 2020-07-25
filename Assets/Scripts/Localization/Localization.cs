using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Localization : MonoBehaviour
{
    public Dictionary<Language, Dictionary<string, string>> Keys;

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
        Language language = LanguageManager.instance.Language;
        if (!instance.Keys[language].ContainsKey(key)) return $"[{key}][{language}] Key not found";
        return instance.Keys[language][key];
    }

    void InitKeys()
    {
        Keys = new Dictionary<Language, Dictionary<string, string>>();
        Keys[Language.EN] = new Dictionary<string, string>();
        Keys[Language.ES] = new Dictionary<string, string>();

        // Spanish
        // Quests and tasks
        Keys[Language.ES]["task1-1"] = "Acomoda tu habitación.";
        
        Keys[Language.ES]["task2-1"] = "Recoge la ropa sucia en tu habitación.";
        Keys[Language.ES]["task2-2"] = "Lleva la ropa sucia al lavarropas.";
        
        Keys[Language.ES]["task3-1"] = "Escapate! Busca una puerta para salir.";
        Keys[Language.ES]["task3-2"] = "Tu teléfono está sonando, ve a la habitación para atenderlo!";
        Keys[Language.ES]["task3-3"] = "Busca el teléfono que realmente está sonando.";
        Keys[Language.ES]["task3-4"] = "";
        Keys[Language.ES]["task3-5"] = "Apaga el TV.";
        
        Keys[Language.ES]["task4-1"] = "Ve a la cocina para hablar con tu pareja.";
        
        Keys[Language.ES]["hint-generic"] = "Presiona 'e' para interactuar.";
        Keys[Language.ES]["hint-1"] = "Presiona 'e' para tender la cama.";
        Keys[Language.ES]["hint-2"] = "Presiona 'e' para cerrar el cajón.";
        Keys[Language.ES]["hint-3"] = "Presiona 'e' para acomodar el cuadro.";
        Keys[Language.ES]["hint-4"] = "Presiona 'e' para recoger la ropa sucia.";
        Keys[Language.ES]["hint-5"] = "Presiona 'e' para tirar la ropa sucia en el lavarropas.";
        Keys[Language.ES]["hint-6"] = "Presiona 'e' para escaparse por la puerta.";
        Keys[Language.ES]["hint-7"] = "Presiona 'e' para atender el teléfono.";
        Keys[Language.ES]["hint-8"] = "Presiona 'e' para apagar el televisor.";
        
        // UI Info
        Keys[Language.ES]["info.restart"] = "Presiona 'R' para reiniciar.";
        
        // Subtitles
        Keys[Language.ES]["voice-1"] = "Voz: MATEO! MATEOOO! Despiertate ya! Todo el día durmiendo!";
        Keys[Language.ES]["voice-2"] = "Voz: Levantate y ordena ese cuarto mugroso! Tiende la cama y pon un poco de orden, madre mia!";
        Keys[Language.ES]["voice-3"] = "Voz: Y no te olvides de llevar esa ropa toda sucia al lavarropas!";
        Keys[Language.ES]["voice-4"] = "Voz: MATEEEEEEO, el televisor está prendido, apágalo por favor!";
        Keys[Language.ES]["voice-5"] = "Voz: Tenemos que hablar, ven a la cocina. YA!";
        Keys[Language.ES]["voice-6"] = "Heladera: No puede ser que estés todo el día jugando a los jueguitos de computadora. ¡Tienes que ponerte las pilas y hacer algo!";
        
        Keys[Language.ES]["m-voice-1"] = "Lavarropas: ¡Qué pasa acá! ¿Por qué están todos gritando?";
        Keys[Language.ES]["m-voice-2"] = "Lavarropas: Pero... tu también eres una heladera!";
        
        Keys[Language.ES]["p-voice-1"] = "Mateo: Madre mía, esa ropa estaba llena de sangre, tengo que irme de aquí.";
        Keys[Language.ES]["p-voice-2"] = "Mateo: Maldición, esa puerta está cerrada.";
        Keys[Language.ES]["p-voice-3"] = "Mateo: Estaba muy seguro de que este era el teléfono que sonaba.";
        Keys[Language.ES]["p-voice-4"] = "Mateo: ¿Cómo es que este teléfono funciona? Ni siquiera está conectado.";
        Keys[Language.ES]["p-voice-5"] = "Mateo: Es la última vez que me caso con una heladera!";
        Keys[Language.ES]["p-voice-6"] = "Mateo: Noooooooo!!!";
        
        Keys[Language.ES]["menu-play-button"] = "Empezar";
        Keys[Language.ES]["menu-exit-button"] = "Salir";

        // English
        // Quests and tasks
        Keys[Language.EN]["task1-1"] = "Tidy up your room.";
        
        Keys[Language.EN]["task2-1"] = "Pick up the dirty clothes in your room.";
        Keys[Language.EN]["task2-2"] = "Take the dirty clothes to the washing machine.";
        
        Keys[Language.EN]["task3-1"] = "Get out! Find an exit door!";
        Keys[Language.EN]["task3-2"] = "Your mobile phone is ringing, go to your room to pick it up.";
        Keys[Language.EN]["task3-3"] = "Find the phone that is actually ringing.";
        Keys[Language.EN]["task3-4"] = "";
        Keys[Language.EN]["task3-5"] = "Turn off the TV.";
        
        Keys[Language.EN]["task4-1"] = "Go to the kitchen to talk to your partner.";
        
        Keys[Language.EN]["hint-generic"] = "Press 'e' to interact.";
        Keys[Language.EN]["hint-1"] = "Press 'e' to make the bed.";
        Keys[Language.EN]["hint-2"] = "Press 'e' to close the drawer.";
        Keys[Language.EN]["hint-3"] = "Press 'e' to move the painting.";
        Keys[Language.EN]["hint-4"] = "Press 'e' to pick up the dirty clothes.";
        Keys[Language.EN]["hint-5"] = "Press 'e' to put the dirty clothes in the washing machine.";
        Keys[Language.EN]["hint-6"] = "Press 'e' to escape through the door.";
        Keys[Language.EN]["hint-7"] = "Press 'e' to pick up the phone.";
        Keys[Language.EN]["hint-8"] = "Press 'e' to turn off the TV.";
        
        // UI Info
        Keys[Language.EN]["info.restart"] = "Press 'R' to restart.";
        
        // Subtitles
        Keys[Language.EN]["voice-1"] = "Voice: MATEO! MATEOOO! Wake up now! You sleep all day!";
        Keys[Language.EN]["voice-2"] = "Voice: Get up and tidy up that filthy room! Make the bed and tidy up, for God's sake!";
        Keys[Language.EN]["voice-3"] = "Voice: And don't forget to take those dirty clothes to the washing machine!";
        Keys[Language.EN]["voice-4"] = "Voice: MATEEEEEEO, The TV is on, please turn it off!";
        Keys[Language.EN]["voice-5"] = "Voice: We need to talk, come to the kitchen NOW!";
        Keys[Language.EN]["voice-6"] = "Fridge: You can't just play computer games all day long. You have to get your act together and do something!";
        
        Keys[Language.EN]["m-voice-1"] = "Washing machine: What's going on here?! What's everybody yelling about?!";
        Keys[Language.EN]["m-voice-2"] = "Washing machine: But... You are also a fridge...";
        
        Keys[Language.EN]["p-voice-1"] = "Mateo: Oh my God, those clothes were full of blood, I have to get out of here.";
        Keys[Language.EN]["p-voice-2"] = "Mateo: Damn, that door is locked.";
        Keys[Language.EN]["p-voice-3"] = "Mateo: I was pretty sure this was the phone that was ringing.";
        Keys[Language.EN]["p-voice-4"] = "Mateo: How does this phone work? It's not even connected.";
        Keys[Language.EN]["p-voice-5"] = "Mateo: This is the last time I'm marrying a fridge!";
        Keys[Language.EN]["p-voice-6"] = "Mateo: Noooooooo!!!";
        
        Keys[Language.EN]["menu-play-button"] = "Start";
        Keys[Language.EN]["menu-exit-button"] = "Exit";
    }
}