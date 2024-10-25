using UnityEngine;

public class ChangeTrigger : MonoBehaviour
{
    public Transform newTarget;  // Nuevo objetivo que se asignará al NPC
    private bool playerPassed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerPassed = true; // Marca que el jugador ha pasado por el trigger
            MoveToTarget2D npc = FindObjectOfType<MoveToTarget2D>(); // Busca el NPC
            if (npc != null)
            {
                npc.SetNewTarget(newTarget); // Cambia el objetivo del NPC
            }
        }
    }

    public bool HasPlayerPassed()
    {
        return playerPassed;
    }
}
