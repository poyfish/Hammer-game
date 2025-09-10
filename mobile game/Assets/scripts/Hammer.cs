using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
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
            anim.CrossFade(HammerObject.HammerAnimation.name, 0, 0);

            if (HammerObject.Effect != null) HammerObject.Effect.OnHit(this);

            sprite.flipX = isMouseRight;

            HitCounter++;

            isHammeringRight = isMouseRight;
        }
    }

    private Timer timer = new Timer(2000);

    private void HandleSpecialHammer()
    {
        hammerColliderLeft.edgeRadius = HammerObject.EdgeRadius;
        hammerColliderRight.edgeRadius = HammerObject.EdgeRadius;
        if (Input.GetMouseButtonDown(0) && !isHammering)
        {
            timer.Start();
        }
        if (Input.GetMouseButtonUp(0) && !isHammering)
        {
            timer.Stop();
            if (timer.)
            {

            }
        }
    }


    IEnumerator ActivateCollider()
    {
        GameObject colliderObject = isHammeringRight ? hammerColliderRight.gameObject : hammerColliderLeft.gameObject;

        isHammering = true;
        colliderObject.SetActive(true);

        yield return new WaitForSeconds(.1f);

        colliderObject.SetActive(false);

        yield return new WaitForSeconds(HammerObject.Cooldown);

        anim.CrossFade(HammerObject.IdleAnimation.name,0,0);

        isHammering = false;
    }

    void HitGround()
    {
        shake.Shake(HammerObject.cycles, HammerObject.force, HammerObject.interval);
        HitSoundSource.PlayOneShot(HammerObject.HitSound,1);
    }

    public void ChangeHammer(HammerObject hammer)
    {
        HammerObject = hammer;

        anim.CrossFade(HammerObject.IdleAnimation.name, 0, 0);
    }
}
