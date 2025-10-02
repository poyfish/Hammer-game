using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    Enemy enemy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        rb.velocity = new Vector2((sprite.flipX ? -1 : 1) * enemy.speed, rb.velocity.y);
    }
}
