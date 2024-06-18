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


    void Start()
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

        hammerColliderLeft.edgeRadius = HammerObject.EdgeRadius;
        hammerColliderRight.edgeRadius = HammerObject.EdgeRadius;

        Vector3 mousePosition = Input.mousePosition;

        
        isMouseRight = mousePosition.x >= Screen.width / 2;

     
        if (Input.GetMouseButtonDown(0) && !isHammering)
        {
            anim.CrossFade(HammerObject.HammerAnimation.name, 0, 0);

            sprite.flipX = isMouseRight;

            isHammeringRight = isMouseRight;

            //StartCoroutine(ActivateCollider());
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
}
