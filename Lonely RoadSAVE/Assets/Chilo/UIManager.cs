using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    #region singleton
    public static UIManager Instance { get; private set; }
    #endregion

    [SerializeField] private GameObject _uiEvent = null;
    [SerializeField] private Image _uiImage;
    private bool _isTextActive = false;
    int currentText = 0;
    public int _damageEvent1 = default; 
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
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

    public void UpdateShowEvent(EventInfo neweventInfo)
    {
        _uiImage.sprite = neweventInfo.EventImage;
        _damageEvent1 = neweventInfo.Damageoption1;
        _uiEvent.SetActive(true);
    }


    public void ButtonOption1()
    {
        
        Player.Instance.TakeDamageFromEvent(_damageEvent1);
        Debug.Log("El jugador recibe daño de evento");
        _uiEvent.SetActive(false) ;
    }

    public void ButtonOption2()
    {

        _uiEvent.SetActive(false);
    }

}
