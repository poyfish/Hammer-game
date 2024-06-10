using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject RestartButton;


    public Hammer hammer;

    SpriteRenderer sprite;

    Animator anim;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (hammer.isHammeringRight)
        {
            sprite.flipX = true;
        }

        else
        {
            sprite.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D rb = hammer.GetComponent<Rigidbody2D>();

            rb.bodyType = RigidbodyType2D.Dynamic;

            rb.gravityScale = 4;


            anim.CrossFade("player_death",0,0);
        }
    }


    public void OnDeath()
    {
        sprite.enabled = false;

        Invoke("EnableButton", .7f);
    }

    public void EnableButton()
    {
        RestartButton.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
