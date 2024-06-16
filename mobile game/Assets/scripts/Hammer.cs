using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public HammerObject HammerObject;

    public AudioSource HitSoundSource;

    [Foldout("Colliders")]
    public GameObject hammerColliderRight;
    [Foldout("Colliders")]
    public GameObject hammerColliderLeft;

    private bool isMouseRight;
    private bool isHammering;
    [HideInInspector]
    public bool isHammeringRight;

    private Animator anim;
    private SpriteRenderer sprite;
    private CameraShake shake;


    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        shake = FindObjectOfType<CameraShake>();

        hammerColliderLeft.SetActive(false);
        hammerColliderRight.SetActive(false);
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        
        isMouseRight = mousePosition.x >= Screen.width / 2;

     
        if (Input.GetMouseButtonDown(0) && !isHammering)
        {
            StartCoroutine(HitGround());

            anim.CrossFade(HammerObject.HammerAnimation.name, 0, 0);

            sprite.flipX = isMouseRight;

            isHammeringRight = isMouseRight;

            StartCoroutine(ActivateCollider(isHammeringRight ? hammerColliderRight : hammerColliderLeft));
        }
    }


    IEnumerator ActivateCollider(GameObject colliderObject)
    {
        yield return new WaitForSeconds(0.09f);

        isHammering = true;
        colliderObject.SetActive(true);

        yield return new WaitForSeconds(HammerObject.Cooldown);

        colliderObject.SetActive(false);

        anim.CrossFade("hammer idle",0,0);

        isHammering = false;
    }

    IEnumerator HitGround()
    {
        yield return new WaitForSeconds(0.1f);

        shake.Shake(HammerObject.cycles, HammerObject.force, HammerObject.interval);
        HitSoundSource.PlayOneShot(HammerObject.HitSound,1);
    }
}
