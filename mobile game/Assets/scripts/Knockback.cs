using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [HideInInspector] public bool isKnockbackActive;

    // KnockbackActivityTime can be used to paralise enemies while knockback is happening
    public void KnockBack(bool doGetKnockedRight, float knockBackXStrength, float knockBackYStrength, Rigidbody2D rb, float KnockbackActivityTime)
    {
        rb.velocity = new Vector2(doGetKnockedRight ? knockBackXStrength : -knockBackXStrength, knockBackYStrength);

        StartCoroutine(KnockBackActivityTimer(KnockbackActivityTime));
    }

    IEnumerator KnockBackActivityTimer(float KnockbackActivityTime)
    {
        isKnockbackActive = true;
        yield return new WaitForSeconds(KnockbackActivityTime);
        isKnockbackActive = false;
    }
}
