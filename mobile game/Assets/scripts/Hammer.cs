using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public HammerObject HammerObject;

    public AudioSource HitSoundSource;

    [Foldout("Colliders")]
    public CompositeCollider2D hammerColliderRight;
    [Foldout("Colliders")]
    public CompositeCollider2D hammerColliderLeft;

    private bool isMouseRight;
    private bool isHammering;
    [HideInInspector]
    public bool isHammeringRight;

    [HideInInspector]
    public Animator anim;
    private SpriteRenderer sprite;
    private CameraShake shake;

    [HideInInspector]
    public int HitCounter;

    private bool isUsingSpecialAttack;

    private bool canInteruptChargeUpAnimation = true;

    void Awake()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        shake = FindObjectOfType<CameraShake>();

        hammerColliderLeft.gameObject.SetActive(false);
        hammerColliderRight.gameObject.SetActive(false);

        anim.CrossFade(HammerObject.IdleAnimation.name, 0, 0);
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        isMouseRight = mousePosition.x >= Screen.width / 2;

        if (HammerObject.IsSpecial)
        {
            HandleSpecialHammer();
        }
        else
        {
            HandleHammer();
        }
    }

    private void HandleHammer()
    {
        hammerColliderLeft.edgeRadius = HammerObject.EdgeRadius;
        hammerColliderRight.edgeRadius = HammerObject.EdgeRadius;

        if (Input.GetMouseButtonDown(0) && !isHammering)
        {
            RegularHit();
        }
    }

    float SpecialChargeUpTimer;

    private void HandleSpecialHammer()
    {
        hammerColliderLeft.edgeRadius = HammerObject.EdgeRadius;
        hammerColliderRight.edgeRadius = HammerObject.EdgeRadius;

        SpecialChargeUpTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && !isHammering)
        {
            canInteruptChargeUpAnimation = false;
            anim.CrossFade(HammerObject.SpecialAbilityChargeUpAnimation.name, 0.1f, 0, 0);
        }

        if (Input.GetMouseButton(0) && !isHammering)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName(HammerObject.SpecialAbilityChargeUpAnimation.name))
            {
                anim.CrossFade(HammerObject.SpecialAbilityChargeUpAnimation.name, 0.1f, 0, 0);
            }
        }

        if (Input.GetMouseButtonUp(0) && !isHammering)
        {
            canInteruptChargeUpAnimation = true;

            if (SpecialChargeUpTimer < HammerObject.specialAbilityChargeUpTime)
            {
                RegularHit();
            }
            else
            {
                SpecialHit();
            }

            SpecialChargeUpTimer = 0;
        }
    }

    // this is literal hell spawn, I have no idea why I need it, it dosn't show up anywhere else, but it gives errors when I delete it
    IEnumerator ActivateCollider()
    {
        GameObject colliderObject = isHammeringRight ? hammerColliderRight.gameObject : hammerColliderLeft.gameObject;

        isHammering = true;
        colliderObject.SetActive(true);

        yield return new WaitForSeconds(.1f);

        colliderObject.SetActive(false);

        yield return new WaitForSeconds(HammerObject.Cooldown);

        if (canInteruptChargeUpAnimation)
        {
            anim.CrossFade(HammerObject.IdleAnimation.name, 0, 0);
        }

        isHammering = false;
    }

    void HitGround()
    {
        shake.Shake(HammerObject.cycles, HammerObject.force, HammerObject.interval);
        HitSoundSource.PlayOneShot(HammerObject.HitSound, 1);
    }

    public void ChangeHammer(HammerObject hammer)
    {
        HammerObject = hammer;

        anim.CrossFade(HammerObject.IdleAnimation.name, 0, 0);
    }

    private void RegularHit()
    {
        anim.CrossFade(HammerObject.HammerAnimation.name, 0, 0);

        if (HammerObject.Effect != null) HammerObject.Effect.OnHit(this);

        sprite.flipX = isMouseRight;

        HitCounter++;

        isHammeringRight = isMouseRight;
    }

    private void SpecialHit()
    {
        anim.CrossFade(HammerObject.HammerAnimation.name, 0, 0);

        if (HammerObject.Effect != null) HammerObject.SpecialEffect.OnHit(this);

        sprite.flipX = isMouseRight;

        HitCounter++;

        isHammeringRight = isMouseRight;
    }
}
