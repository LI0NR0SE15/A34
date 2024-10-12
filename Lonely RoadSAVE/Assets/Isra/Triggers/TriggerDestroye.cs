using UnityEngine;

public class TriggerDestroye : MonoBehaviour
{
    public GameObject objectToDestroy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Destruye el objeto especificado
            if (objectToDestroy != null)
            {
                Destroy(objectToDestroy);
                Debug.Log("Objeto destruido.");
            }
            else
            {
                Debug.LogWarning("Objeto no asignado en el inspector.");
            }
        }
    }
}