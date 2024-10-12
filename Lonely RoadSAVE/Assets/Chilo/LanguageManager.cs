using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager instance;

    public static LanguageManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    public Action OnLanguageChange;

    public Languages currenLanguage = Languages.Spanish; // seteamos que el lenguaje inicial es el español

    void ChangeToNextLanguage() // llamarlo de un menu de settings
    {
        currenLanguage++; // vamos aumentando la variable segun los lenguajes que tenemos
        if (currenLanguage >= Languages.MAX) // delimitamos los lenguajes que existen
        {
            currenLanguage = 0;
        }

        if (OnLanguageChange != null) // se declara que si el cambio de lenguaje no es nulo, es decir, que hay un lenguaje. Vamos a cambiar el idioma
        {
            OnLanguageChange.Invoke();
        }
        Debug.Log("Se cambio");
    }


    public int GetCurrentLanguage() // Metodo para obtener el languaje actual
    {
        return (int)currenLanguage;
    }

    public enum Languages
    {
        Spanish,
        English,
        MAX
    }

}
