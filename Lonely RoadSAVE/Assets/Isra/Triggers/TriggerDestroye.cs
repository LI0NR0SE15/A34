using UnityEngine;

public class TriggerDestroye : MonoBehaviour
{
    public GameObject objectToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Destruye el objeto especificado
            if (objectToDestroy != null)
            {
                Destroy(objectToDestroy);
                Debug.Log("Objeto destruido.");
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Objeto no asignado en el inspector.");
            }
        }
    }
}