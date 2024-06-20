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


    public override void ApplyEffect(Enemy Target)
    {
        Target.Kill();
    }

    public override void OnHit(Hammer hammer)
    {
        if(hammer.HitCounter % 3 == 0)
        {
            hammer.StartCoroutine(ShockWave());
        }
    }

    public IEnumerator ShockWave()
    {
        yield return null;
    }
}
