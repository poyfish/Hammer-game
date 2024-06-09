using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyStats[] enemies;
    public float timeBetweenSpawns;

    public int lapNumber;


    public bool isSpwanerSpwaningRight;

    [System.Serializable]
    public struct EnemyStats
    {
        public GameObject Prefab;

        public float speed;

        public int difficulty;
    }

    public struct EnemyInfo
    {
        public GameObject gameObject;

        public Rigidbody2D rb;

        public Collider2D coll;

        public SpriteRenderer sprite;

        public EnemyStats stats;

        public EnemyInfo(GameObject g, Rigidbody2D r, Collider2D c, SpriteRenderer s, EnemyStats es)
        {
            gameObject = g;
            rb = r;
            coll = c;
            sprite = s;
            stats = es;
        }
    }


    public List<EnemyInfo> SpawnedEnemies = new List<EnemyInfo>();

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        MoveEnemies();
    }

    public void DiscardEnemy(EnemyInfo Info)
    {
        if (!SpawnedEnemies.Contains(Info)) return;

        SpawnedEnemies.Remove(Info);
    }

    IEnumerator SpawnEnemies()
    {

        for (int i = 0; i < lapNumber; i++)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);

            if (enemies.Length > 0)
            {
                int randomIndex = Random.Range(0, enemies.Length);
                GameObject enemy = Instantiate(enemies[randomIndex].Prefab, transform.position, Quaternion.identity, transform);

                EnemyInfo enemyInfo = new EnemyInfo(enemy, enemy.GetComponent<Rigidbody2D>(), enemy.GetComponent<Collider2D>(), enemy.GetComponent<SpriteRenderer>(), enemies[randomIndex]);

                SpawnedEnemies.Add(enemyInfo);

                enemy.GetComponent<Enemy>().Info = enemyInfo;

                foreach (Enemy other in FindObjectsOfType<Enemy>())
                {
                    Physics2D.IgnoreCollision(enemyInfo.coll, other.GetComponent<Collider2D>());
                }
            }
            else
            {
                Debug.LogError("No enemies assigned to the spawner!");
            }
        }
    }

    void MoveEnemies()
    {
        foreach (EnemyInfo enemy in SpawnedEnemies)
        {
            enemy.sprite.flipX = !isSpwanerSpwaningRight;

            enemy.rb.velocity = new Vector2((isSpwanerSpwaningRight ? 1 : -1) * enemy.stats.speed, enemy.rb.velocity.y);
        }
    }
}
