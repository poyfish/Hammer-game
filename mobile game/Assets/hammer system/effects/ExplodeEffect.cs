using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Hammer Effect", menuName = "Hammer Effects/Explode Effect", order = 99)]
public class ExplodeEffect : HammerEffect
{
    public Vector2 MinLaunchForce;
    public Vector2 MaxLaunchForce;

    public float ExploationRadius;

    public LayerMask EnemyMask;

    [Foldout("Shake Settings")]
    public int cycles;
    [Foldout("Shake Settings")]
    public float force;
    [Foldout("Shake Settings")]
    public float interval;

    private CameraShake shake;


    public override void ApplyEffect(Enemy Target)
    {
        if(shake == null) 
        {
            shake = FindObjectOfType<CameraShake>();
        }

        Target.Discard();

        Vector2 LaunchForceMin = MaxLaunchForce;
        Vector2 LaunchForceMax = MinLaunchForce;

        LaunchForceMax.x *= Target.Info.isRight ? -1 : 1;
        LaunchForceMin.x *= Target.Info.isRight ? -1 : 1;

        Target.enabled = false;

        Target.Info.rb.velocity = new Vector2(Random.Range(LaunchForceMin.x, LaunchForceMax.x), Random.Range(LaunchForceMin.y, LaunchForceMax.y));

        Target.StartCoroutine(Explode(Target));
    }

    public IEnumerator Explode(Enemy Target)
    {
        yield return new WaitForSeconds(.2f);

        yield return new WaitUntil(() => Target.IsGrounded());

        Target.Kill();

        RaycastHit2D[] hits = Physics2D.CircleCastAll(Target.transform.position, ExploationRadius, Vector2.zero, 0, EnemyMask);

        foreach (RaycastHit2D hit in hits)
        {
            hit.collider.gameObject.GetComponent<Enemy>().Kill();
        }

        shake.Shake(cycles, force, interval);
    }

}
