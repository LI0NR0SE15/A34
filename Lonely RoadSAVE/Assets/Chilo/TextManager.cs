using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    #region singleton
    private static TextManager instance;
    public static TextManager GetInstance()
    {
        return instance;
    }
    #endregion

    [SerializeField] GameObject textContainer;
    [SerializeField] EventInfo eventToShow;
    [SerializeField] public TMP_Text uiText;

    bool continueToNextText = false;
    int currentText = 0;
    bool isTextActive = false;

    void Awake()
    {
        instance = this;
        Debug.Log("Instancia de texmanager creada");
    }
    void Start()
    {
        ChangeNextText();
        LanguageManager.GetInstance().OnLanguageChange += OnLanguageChange;
    }

    public void ShowUIText(EventInfo _newEventToSHow)
    {
        isTextActive = true;
        eventToShow = _newEventToSHow;
        textContainer.SetActive(true);
        currentText = 0;
        ChangeNextText();
    }
    void OnLanguageChange()
    {
        if (!isTextActive) return;
        {
            uiText.text = eventToShow.GetText(currentText - 1);
        }
    }
    void FixedUpdate()
    {
        if (!isTextActive) return;
        {
            Debug.Log("Entra en el otro texto");
            continueToNextText = false;
            ChangeNextText();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            continueToNextText = true;
        }
    }
    void ChangeNextText()
    {
        if (eventToShow.IsThereAnotherText(currentText))
        {
            uiText.text = eventToShow.GetText(currentText);
            currentText++; // prepara para siguiente texto
            Debug.Log("Cambia el texto");
        }
        else
        {
            CloseUI();
        }

    }

    void CloseUI()
    {
        textContainer.SetActive(false);
        Debug.Log("Todos los textos se llamaron,Se cerro el dialogo");
    }
}
