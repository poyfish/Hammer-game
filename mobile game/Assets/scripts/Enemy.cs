using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemySpawner.EnemyInfo Info;

    Animator anim;


    public string squashed_animation_name;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hammer"))
        {
            Info.rb.constraints = RigidbodyConstraints2D.FreezeAll;
            anim.CrossFade(squashed_animation_name,0,0);
            Invoke("Destroy", 2f);
        }
    }


    private void Destroy()
    {
        foreach (EnemySpawner spawner in FindObjectsOfType<EnemySpawner>())
        {
            spawner.DiscardEnemy(Info);
        }

        Destroy(this.gameObject);    
    }
}
