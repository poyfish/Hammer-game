using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCulling : MonoBehaviour
{
    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Cull")) return;

        foreach (EnemySpawner spawner in FindObjectsOfType<EnemySpawner>())
        {
            spawner.DiscardEnemy(enemy.Info);
        }

        Destroy(this.gameObject);
    }
}
