using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerProbability : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra es el jugador.
        if (other.CompareTag("Player"))
        {
            // Genera un número aleatorio 0 o 1, simulando una moneda (50/50).
            int result = Random.Range(0, 2);  // 0 o 1

            if (result == 0)
            {
                Debug.Log("Si");
            }
            else
            {
                Debug.Log("No");
            }
        }
    }
}