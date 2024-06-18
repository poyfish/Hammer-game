using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "New Hammer Object", menuName = "Hammer Object", order = 99)]
public class HammerObject : ScriptableObject
{
    [ShowAssetPreview]
    public Sprite Icon;

    public AnimationClip HammerAnimation;
    public AnimationClip DeathAnimation;

    public float Cooldown;

    public AudioClip HitSound;

    [Foldout("Shake Settings")]
    public int cycles;
    [Foldout("Shake Settings")]
    public float force;
    [Foldout("Shake Settings")]
    public float interval;

    public HammerEffect Effect;
}
