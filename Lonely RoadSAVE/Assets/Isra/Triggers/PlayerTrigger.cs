using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private bool playerPassed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerPassed = true; // Marca que el jugador ha pasado por el trigger
        }
    }

    public bool HasPlayerPassed()
    {
        return playerPassed;
    }
}
