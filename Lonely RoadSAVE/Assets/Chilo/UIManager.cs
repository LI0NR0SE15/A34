using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    #region singleton
    private static UIManager instance;
    public static UIManager GetInstance()
    {
        return instance;
    }
    #endregion

    [SerializeField] private GameObject _uiEvent = null;
    [SerializeField] public TMP_Text _uiText;
    [SerializeField] public Image _uiImage;
    private bool _isTextActive = false;
    int currentText = 0;
    public int _damageEvent1 = default;
    public EventInfo _eventInfo = null; 

    public GameObject UIevent => _uiEvent;
    

    private void Awake()
    {
        instance = this;
        Debug.Log("Instancia de UIManager creada");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowEvent(EventInfo neweventInfo)
    {
        _eventInfo = neweventInfo;
        _uiEvent.SetActive(true);
    }


    public void ButtonOption1()
    {
        SetDamageEventOption1();
        Player.Instance.TakeDamageFromEvent(_damageEvent1);
        Debug.Log("El jugador recibe daño de evento");
        _uiEvent.SetActive(false) ;
    }

    public void ButtonOption2()
    {

        _uiEvent.SetActive(false);
    }

    public void SetDamageEventOption1()
    {
        _eventInfo.GetDamageOption1(_damageEvent1);
        Debug.Log("se seteo el damño de la opcion 1");
    }

    void OnLanguageChange()
    {
        if (!_isTextActive) return;
        {
            _uiText.text = _eventInfo.GetText(currentText - 1);
        }
    }
}
