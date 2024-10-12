using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ExampleSaveScript : MonoBehaviour
{
    [SerializeField] Vector2 position;
    [SerializeField] Transform playerPosition;
    public void Save() {
        ProgressAndVolumeAndIluminationSaver.Instance.recivirPosicion(position);
    }
    public void FixedUpdate()
    {
        position = playerPosition.transform.position;
    }
}
