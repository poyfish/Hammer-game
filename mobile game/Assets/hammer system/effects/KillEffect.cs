using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hammer Effect", menuName = "Hammer Effects/Kill Effect", order = 99)]
public class KillEffect : HammerEffect
{
    public override void ApplyEffect(Enemy Target)
    {
        Target.Kill();
    }
}
