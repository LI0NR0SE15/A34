using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour
{
    Rigidbody2D rigi;
    [SerializeField]float frictionPorcentage,totalFriction;
    [SerializeField] Vector2 RealFriction;
    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        totalFriction = frictionPorcentage / 25;
        RealFriction = new Vector2(-rigi.velocity.x*totalFriction,-rigi.velocity.y*totalFriction);
        rigi.velocity += RealFriction*Time.fixedDeltaTime;
    }
}
