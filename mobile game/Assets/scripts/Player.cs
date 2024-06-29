using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Hammer hammer;

    SpriteRenderer sprite;

    Animator anim;

    public UnityEvent OnPlayerDeath;
    public float DeathEventDelay;

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
            anim.CrossFade("player_death",0,0);

            hammer.enabled = false;

            hammer.anim.CrossFade(hammer.HammerObject.DeathAnimation.name, 0, 0);
        }
    }


    public void OnDeath()
    {
        sprite.enabled = false;

        Invoke("InvokeDeathEvent", DeathEventDelay);
    }

    void InvokeDeathEvent()
    {
        OnPlayerDeath.Invoke();
    }
}
