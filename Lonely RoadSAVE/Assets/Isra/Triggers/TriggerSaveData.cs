using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSaveData : MonoBehaviour
{
    public GameObject canvas;  // Arrastra el Canvas en esta variable desde el inspector.

    void Start()
    {
        // Asegúrate de que el Canvas esté inicialmente desactivado.
        canvas.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra es el jugador (puedes cambiar el tag a lo que prefieras).
        if (other.CompareTag("Player"))
        {
            // Activa el Canvas cuando el jugador entre en el trigger.
            canvas.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Verifica si el objeto que sale es el jugador.
        if (other.CompareTag("Player"))
        {
            // Desactiva el Canvas cuando el jugador salga del trigger.
            canvas.SetActive(false);
        }
    }
}

