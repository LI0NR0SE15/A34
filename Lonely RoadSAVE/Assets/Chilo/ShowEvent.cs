using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEvent : MonoBehaviour
{
    [SerializeField] private EventInfo _eventInfo = default;
    [SerializeField] private UIManager _UIevent = default;
    [SerializeField] private GameObject _eventUI = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Player")) return;
        Debug.Log("Colisiono el jugador");
       // _UIevent.ShowEvent(_eventInfo);
       _eventUI.SetActive(true);
    }

}
