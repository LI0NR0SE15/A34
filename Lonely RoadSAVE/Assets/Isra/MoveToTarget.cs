using UnityEngine;

public class MoveToTarget2D : MonoBehaviour
{
    public Transform target;  // El objeto vacío al que se moverá el NPC
    public float speed = 2f;  // Velocidad de movimiento
    public float distanceOffset = 2f;  // Distancia a mantener del nuevo objetivo

    private Rigidbody2D rb;
    private PlayerTrigger playerTrigger;  // Referencia al script del trigger
    private bool canMove = false;  // Variable para controlar el movimiento

    private void Start()
    {
        // Obtener el Rigidbody2D del NPC
        rb = GetComponent<Rigidbody2D>();
        // Obtener la referencia al trigger
        playerTrigger = FindObjectOfType<PlayerTrigger>();  // Busca el objeto PlayerTrigger en la escena
    }

    private void Update()
    {
        // Verifica si el jugador ha pasado por el trigger
        if (playerTrigger != null && playerTrigger.HasPlayerPassed())
        {
            canMove = true;  // Permitir el movimiento del NPC
        }

        if (canMove && target != null)
        {
            // Verificar si el NPC está dentro del área del gizmo
            Player player = Player.Instance;
            if (player != null)
            {
                float playerRadius = player.GizmoRadius;
                float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

                // Si el NPC está dentro del radio, no se mueve
                if (distanceToPlayer < playerRadius)
                {
                    rb.velocity = Vector2.zero; // Detener el movimiento
                    return; // No continuar con el movimiento hacia el objetivo
                }
            }

            // Calcular la dirección hacia el objetivo
            Vector2 direction = (target.position - transform.position).normalized;

            // Calcular la distancia al objetivo
            float distance = Vector2.Distance(transform.position, target.position);

            // Si está cerca del objetivo, detenerse
            if (distance > 0.1f)  // Puedes ajustar este valor si es necesario
            {
                // Mover el Rigidbody2D hacia el objetivo
                rb.velocity = direction * speed;  // Aplica la velocidad al Rigidbody2D
            }
            else
            {
                // Detener el movimiento
                rb.velocity = Vector2.zero;  // Detiene el Rigidbody2D
                canMove = false; // Evitar que se mueva nuevamente después de llegar
            }
        }
        else
        {
            // Si no se puede mover, asegurar que la velocidad sea cero
            rb.velocity = Vector2.zero;
        }
    }

    public void SetNewTarget(Transform newTarget)
    {
        // Cambia el objetivo y posiciona al NPC a 2 unidades de distancia
        target = newTarget;
        Vector2 direction = (newTarget.position - transform.position).normalized;
        transform.position = newTarget.position - (Vector3)direction * distanceOffset; // Coloca al NPC a 2 unidades de distancia
    }
}