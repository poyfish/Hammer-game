using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemySpawner;
using static EnemyPool;
using System.Linq;
using NaughtyAttributes;

public class DifficultyManager : MonoBehaviour
{
    [Header("Difficulty")]

    [ReadOnly]
    public float Difficulty;

    public float DifficultySpeed;

    [Header("Spawn Times")]

    [ReadOnly]
    public float SpawnTimeMin;

    [ReadOnly]
    public float SpawnTimeMax;

    public float SpawnTimeSpeedMin;

    public float SpawnTimeSpeedMax;

    void Update()
    {
        Difficulty += Time.deltaTime * DifficultySpeed;

        SpawnTimeMin += Time.deltaTime * SpawnTimeSpeedMin;

        SpawnTimeMax += Time.deltaTime * SpawnTimeSpeedMax;
    }

    public EnemyPool GetCulledPool(EnemyPool Pool)
    {
        EnemyPool NewPool = Instantiate(Pool);

        NewPool.enemies = NewPool.enemies.Where(E => E.difficultyMin < Difficulty).ToArray();

        return NewPool;
    }

    public EnemyPool GetAppliedSpawnTimePool(EnemyPool Pool)
    {
        EnemyPool NewPool = Instantiate(Pool);

        NewPool.timeBetweenSpawnsMin -= SpawnTimeMin;

        NewPool.timeBetweenSpawnsMax -= SpawnTimeMax;

        NewPool.timeBetweenSpawnsMin = Mathf.Clamp(NewPool.timeBetweenSpawnsMin, 0, float.MaxValue);

        NewPool.timeBetweenSpawnsMax = Mathf.Clamp(NewPool.timeBetweenSpawnsMax, 0, float.MaxValue);

        return NewPool;
    }
}
