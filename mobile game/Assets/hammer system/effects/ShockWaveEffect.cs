using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hammer Effect", menuName = "Hammer Effects/Shokwave Effect", order = 99)]
public class ShockWaveEffect : HammerEffect
{
    public float spawnY;
    public float spawnOffsetX;

    public float OffsetBetweenSpawns;
    public float TimeBetweenSpawns;

    public int SpikeAmount;

    public GameObject Spike;


    public override void ApplyEffect(Enemy Target)
    {
        Target.Kill();
    }

    public override void OnHit(Hammer hammer)
    {
        if(hammer.HitCounter % 3 == 0)
        {
            hammer.StartCoroutine(ShockWave(hammer));
        }
    }

    public IEnumerator ShockWave(Hammer hammer)
    {
        yield return null;

        Vector2 startPos  = new Vector2(hammer.transform.position.x + (hammer.isHammeringRight ? spawnOffsetX : -spawnOffsetX), spawnY);

        List<GameObject> parents = new List<GameObject>();

        for (int i = 0; i < SpikeAmount; i++)
        {
            var parent = new GameObject("spike parent");

            parents.Add(parent);

            var spike = Instantiate(Spike, parent.transform);

            parent.transform.position = startPos;

            startPos += new Vector2(hammer.isHammeringRight ? OffsetBetweenSpawns : -OffsetBetweenSpawns, 0);

            yield return new WaitForSeconds(TimeBetweenSpawns);
        }

        yield return new WaitForSeconds(1);

        foreach (var parent in parents)
        {
            Destroy(parent);
        }
    }
}
