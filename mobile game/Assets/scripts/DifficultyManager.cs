using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemySpawner;
using static EnemyPool;
using System.Linq;

public class DifficultyManager : MonoBehaviour
{
    public float Difficulty;

    public float DifficultySpeed;

    void Update()
    {
        Difficulty += Time.deltaTime * DifficultySpeed;
    }

    public EnemyPool GetCulledPool(EnemyPool Pool)
    {
        EnemyPool NewPool = Instantiate(Pool);

        NewPool.enemies = NewPool.enemies.Where(E => E.difficultyMin < Difficulty).ToArray();

        return NewPool;
    }
}
