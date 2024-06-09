using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sprite;
    public CameraShake shake;


    public GameObject hammerColliderRight;
    public GameObject hammerColliderLeft;

    public AudioSource hitGround;

    public int cycles;
    public float force;
    public float interval;

    bool isMouseRight;

    bool isHammering;


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

        
        isMouseRight = (mousePosition.x >= Screen.width / 2);

     
        if (Input.GetMouseButtonDown(0))
        {
            if (isMouseRight && !isHammering)
            {
                StartCoroutine(ActivateCollider(hammerColliderRight));
                anim.CrossFade("hammer hammering",0,0);
                sprite.flipX = true;
            }
            else if(!isMouseRight && !isHammering)
            {
                StartCoroutine(ActivateCollider(hammerColliderLeft));
                anim.CrossFade("hammer hammering", 0, 0);
                sprite.flipX = false;               
            }
        }
    }


    IEnumerator ActivateCollider(GameObject colliderObject)
    {
        yield return new WaitForSeconds(0.09f);

        isHammering = true;
        colliderObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        colliderObject.SetActive(false);
        anim.CrossFade("hammer idle",0,0);
        isHammering = false;
    }

    void HitGround(GameObject colliderObject)
    {
        shake.Shake(cycles, force, interval);
        hitGround.Play();
    }
}
