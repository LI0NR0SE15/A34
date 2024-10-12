using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    int maxHealth = 100;
    int currentHealth = default;

    public HealthBar _healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        _healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamageFromEvent(int damage)
    {
        currentHealth -= damage;

        _healthBar.SetHealth(currentHealth);
    }

}
