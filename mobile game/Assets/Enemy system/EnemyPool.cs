using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Pool", menuName = "Enemy Pool", order = 98)]
public class EnemyPool : ScriptableObject
{
    [System.Serializable]
    public struct EnemyStats
    {
        public GameObject Prefab;

        public float speed;

        public int difficultyMin;
    }

    public EnemyStats[] enemies;

    public float timeBetweenSpawnsMin;

    public float timeBetweenSpawnsMax;
}
