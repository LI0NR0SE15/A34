using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEvent : MonoBehaviour
{
    [SerializeField] private GameObject _eventUI = null;
    public EventInfo EventInfo = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Player")) return;
        Debug.Log("Colisiono el jugador");
       // _UIevent.ShowEvent(_eventInfo);
       UIManager.Instance.UpdateShowEvent(EventInfo);
       _eventUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
