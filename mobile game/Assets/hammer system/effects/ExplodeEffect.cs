using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Hammer Effect", menuName = "Hammer Effects/Explode Effect", order = 99)]
public class ExplodeEffect : HammerEffect
{
    public Vector2 MinLaunchForce;
    public Vector2 MaxLaunchForce;

    public float DeathDelay;

    public override void ApplyEffect(Enemy Target)
    {
        Target.Discard();

        Vector2 LaunchForceMin = MaxLaunchForce;
        Vector2 LaunchForceMax = MinLaunchForce;

        LaunchForceMax.x *= Target.Info.isRight ? -1 : 1;
        LaunchForceMin.x *= Target.Info.isRight ? -1 : 1;

        Target.Info.rb.velocity = new Vector2(Random.Range(LaunchForceMin.x, LaunchForceMax.x), Random.Range(LaunchForceMin.y, LaunchForceMax.y));

        Target.Invoke("Kill", DeathDelay);
    }


}
