using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D coll;
    Animator anim;
    Enemy enemy;

    public float jumpForce;
    public float jumpSpeed;

    [SerializeField] private LayerMask jumpableGround;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if(enemy.IsDead) return;

        if (IsGrounded())
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            anim.CrossFade("jumping_enemy_jumping", 0,0);
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
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
