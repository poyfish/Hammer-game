using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public EnemySpawner.EnemyInfo Info;

    private Animator anim;
    private Hammer hammer;

    [HideInInspector]
    public bool IsDead;

    [SerializeField]
    private string squashed_animation_name;

    void Start()
    {
        anim = GetComponent<Animator>();

        hammer = FindObjectOfType<Hammer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hammer"))
        {
            if (hammer.HammerObject.Effect == null) return;

            hammer.HammerObject.Effect.ApplyEffect(this);
        }
    }


    public void Kill()
    {
        IsDead = true;

        Info.rb.constraints = RigidbodyConstraints2D.FreezeAll;
        Info.coll.enabled = false;

        anim.CrossFade(squashed_animation_name, 0, 0);
        Invoke("Destroy", 2f);
    }


    public void Discard()
    {
        foreach (EnemySpawner spawner in FindObjectsOfType<EnemySpawner>())
        {
            spawner.DiscardEnemy(Info);
        }
    }

    public void Destroy()
    {
        foreach (EnemySpawner spawner in FindObjectsOfType<EnemySpawner>())
        {
            spawner.DiscardEnemy(Info);
        }

        Destroy(this.gameObject);    
    }
}
