using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform PositionOfCamera;
    public GameObject SFXObject;
    public Vector3 typeDefiner;

    public async void createEffect(int _type) {
        PositionOfCamera.transform.position = new Vector3(transform.position.x, transform.position.y, _type);
        Debug.Log(PositionOfCamera.transform.position);
        Instantiate(SFXObject,PositionOfCamera.position,PositionOfCamera.localRotation);
    }
}
