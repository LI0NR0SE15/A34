using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para manejar escenas

public class TriggerChangeScene : MonoBehaviour
{
    public string sceneName;  // Nombre de la escena a cargar.

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
