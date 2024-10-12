using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float FollowSpeed = 1.0f;
    public Transform Target;

    void Update()
    {
        Vector3 NewPos = new Vector3(Target.position.x, Target.position.y, -1);
        transform.position = Vector3.Slerp(transform.position, NewPos, FollowSpeed*Time.deltaTime);
    }
}