using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float _speed = default;
    [SerializeField] private Rigidbody2D _rigidbody2D = default;
    private Vector2 _movement = default;

    int maxHealth = 100;
    int Currenthealth;

    public HealthBar _healthBar;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        Currenthealth = maxHealth;
        _healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        _movement.x = Input.GetAxis("Horizontal") * _speed;
        _movement.y = Input.GetAxis("Vertical") * _speed;

    }


    void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _movement * Time.fixedDeltaTime);
    }


   public void TakeDamageFromEvent(int damage)
    {
        Currenthealth -= damage;

        _healthBar.SetHealth(Currenthealth);
    }
}
