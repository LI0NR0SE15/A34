using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MovementSpeed;
    [SerializeField] Rigidbody2D RB;
    Vector2 Movement;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float DirectionX = Input.GetAxis("Horizontal");
        float DirectionY = Input.GetAxis("Vertical");

        Movement = new Vector2(DirectionX, DirectionY) * MovementSpeed;
    }

    void FixedUpdate()
    {
        RB.velocity = Movement;
    }
}