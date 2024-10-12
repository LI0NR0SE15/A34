using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float _speed = default;
    [SerializeField] private Rigidbody2D _rigidbody2D = default;
    private Vector2 _movement = default;

    bool _isAlive = true;
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
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float DirectionX = Input.GetAxis("Horizontal");
        float DirectionY = Input.GetAxis("Vertical");

        _movement = new Vector2(DirectionX, DirectionY) * _speed;
    }


    void FixedUpdate()
    {
        _rigidbody2D.velocity = _movement;
    }


   public void TakeDamageFromEvent(int damage)
    {
        Currenthealth -= damage;

        _healthBar.SetHealth(Currenthealth);
    }

    public void CheckIsPlayerAlive()
    {
        if (_isAlive)
        {
            return;
        }
        else
        {

        }
    }
}
