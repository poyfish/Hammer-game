using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "New Hammer Object", menuName = "Hammer Object", order = 99)]
public class HammerObject : ScriptableObject
{
    [ShowAssetPreview]
    public Sprite Icon;

    public bool IsSpecial;

    public bool HandlesHammerDownAnimation;
    public AnimationClip IdleAnimation;
    public AnimationClip HammerAnimation;
    public AnimationClip DeathAnimation;
    
    [ShowIf("IsSpecial")]
    public AnimationClip SpecialAbilityChargeUpAnimation;
    [ShowIf("IsSpecial")]
    public AnimationClip SpecialAbilityChargeHammerAnimation;

    public float EdgeRadius;

    public float Cooldown;

    public AudioClip HitSound;


    [Foldout("Shake Settings")]
    public int cycles;
    [Foldout("Shake Settings")]
    public float force;
    [Foldout("Shake Settings")]
    public float interval;


    [Foldout("Special Ability Settings"), ShowIf("IsSpecial")]
    public float specialAbilityChargeUpTime;

    public HammerEffect Effect;
    [ShowIf("IsSpecial")]
    public HammerEffect SpecialEffect;
}
