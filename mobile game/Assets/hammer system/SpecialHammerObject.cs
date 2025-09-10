using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Special Hammer Object", menuName = "Special Hammer Object", order = 99)]
public class SpecialHammerObject : HammerObject
{
    public AnimationClip SpecialAbilityChargeUpAnimation;
    public AnimationClip SpecialAbilityChargeHammerAnimation;

    public HammerEffect SpecialEffect;

    [Foldout("Special Ability Settings")]
    public float specialAbilityChargeUpTime;

    public override bool IsSpecial => true;
}
