using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Event info", menuName = "Create Event data")]
public class EventInfo : ScriptableObject
{
    [SerializeField] private string eventName = default;

    public MultiLanguajeText[] textDescriptionToShow;

    [SerializeField] private GameObject uiEvent = default;
    public Texture2D uiImage;

    public string EventName => eventName;
    public GameObject UI => uiEvent;


    public int _damageoption1;
    public int _damageoption2;



    public string GetText(int i)
    {
        return textDescriptionToShow[i].textInLanguage[LanguageManager.GetInstance().GetCurrentLanguage()]; // conseguimos los textos que escribimos y los vamos mostrando segun los arreglos que hay
    }
    public bool IsThereAnotherText(int i)
    {
        return i < textDescriptionToShow.Length; // checamos is no hay algun otro texto para detener la ejecucion
    }

    public int GetDamageOption1(int i) 
    {
        return _damageoption1;
    }

    public int GetDamageOption2(int i)
    {
        return _damageoption2;
    }
}


[Serializable]
public class MultiLanguajeText
{
    public string note;
    [TextArea]
    public string[] textInLanguage; // texto que escribimos en el arreglo
}