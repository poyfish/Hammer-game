using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingMovement : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D coll;
    Animator anim;
    SpriteRenderer sprite;
    Enemy enemy;

    public float jumpForce;

    [SerializeField] private LayerMask jumpableGround;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if (enemy.IsDead)
        {
            return;
        }

        if (IsGrounded())
        {
            anim.CrossFade("jumping_enemy_jumping", 0,0);
        }
        else
        {
            rb.velocity = new Vector2((sprite.flipX ? -1 : 1) * enemy.speed, rb.velocity.y);
            anim.CrossFade("jumping_enemy_mid_air", 0, 0);
        }

    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
