using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static EnemyPool;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPool enemies;

    public bool isSpwanerSpwaningRight;

    private DifficultyManager difficultyManager;

    private Collider2D PlayerColl;

    public struct EnemyInfo
    {
        public GameObject gameObject;

        public Rigidbody2D rb;

        public Collider2D coll;

        public SpriteRenderer sprite;

        public EnemyStats stats;

        public bool isRight;

        public EnemyInfo(GameObject g, Rigidbody2D r, Collider2D c, SpriteRenderer s, EnemyStats es, bool ir)
        {
            gameObject = g;
            rb = r;
            coll = c;
            sprite = s;
            stats = es;
            isRight = ir;
        }
    }


    public List<EnemyInfo> SpawnedEnemies = new List<EnemyInfo>();

    void Start()
    {
        difficultyManager = FindObjectOfType<DifficultyManager>();

        PlayerColl = FindObjectOfType<Player>().GetComponent<Collider2D>();

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

        for (int i = 0; i < int.MaxValue; i++)
        {
            EnemyPool CulledPool = difficultyManager.GetCulledPool(enemies);

            EnemyPool TimePool = difficultyManager.GetAppliedSpawnTimePool(CulledPool);

            yield return new WaitForSeconds(Random.Range(TimePool.timeBetweenSpawnsMin, TimePool.timeBetweenSpawnsMax));

            if (TimePool.enemies.Length > 0)
            {
                int randomIndex = Random.Range(0, CulledPool.enemies.Length);
                GameObject enemy = Instantiate(TimePool.enemies[randomIndex].Prefab, transform.position, Quaternion.identity, transform);

                EnemyInfo enemyInfo = new EnemyInfo(enemy, enemy.GetComponent<Rigidbody2D>(), enemy.GetComponent<Collider2D>(), enemy.GetComponent<SpriteRenderer>(), TimePool.enemies[randomIndex], isSpwanerSpwaningRight);

                SpawnedEnemies.Add(enemyInfo);

                enemy.GetComponent<Enemy>().Info = enemyInfo;

                //Physics2D.IgnoreCollision(enemyInfo.coll, PlayerColl);

                foreach (Enemy other in FindObjectsOfType<Enemy>())
                {
                    Physics2D.IgnoreCollision(enemyInfo.coll, other.GetComponent<Collider2D>());
                }
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
