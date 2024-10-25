using System.Collections.Generic;
using System.Collections;
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

    // Agregar un nuevo campo para el radio del gizmo
    [SerializeField] private float _gizmoRadius = 2f; // Ajusta este valor según tus necesidades

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
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

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

    private void OnDrawGizmos()
    {
        // Dibuja un gizmo de radio amarillo alrededor del jugador
        Gizmos.color = Color.yellow;  // Establecer color del gizmo
        Gizmos.DrawWireSphere(transform.position, _gizmoRadius);  // Dibuja el gizmo
    }

    public float GizmoRadius
    {
        get { return _gizmoRadius; }
    }
}