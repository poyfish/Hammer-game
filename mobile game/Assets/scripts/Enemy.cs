using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int ScoreRewardMin;
    public int ScoreRewardMax;

    [HideInInspector]
    public EnemySpawner.EnemyInfo Info;

    private Animator anim;
    private Hammer hammer;

    [HideInInspector]
    public bool IsDead;

    [SerializeField]
    private string squashed_animation_name;

    public LayerMask GroundMask;

    private ScoreManager scoreManager;

    void Start()
    {
        anim = GetComponent<Animator>();

        hammer = FindObjectOfType<Hammer>();

        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hammer"))
        {
            if (hammer.HammerObject.Effect == null) return;

            hammer.HammerObject.Effect.ApplyEffect(this);
        }
    }


    public bool IsGrounded()
    {
        return Physics2D.BoxCast(Info.coll.bounds.center, Info.coll.bounds.size / 1.1f, 0f, Vector2.down, .1f, GroundMask);
    }


    public void Kill()
    {
        IsDead = true;

        scoreManager.AddScore(Random.Range(ScoreRewardMin, ScoreRewardMax));

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
        Discard();

        Destroy(this.gameObject);    
    }
}
