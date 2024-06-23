using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    bool Frozen;

    public void Apply()
    {
        Frozen = true;
    }

    private void Update()
    {
        if (Frozen)
        {
            foreach (Rigidbody2D rb in FindObjectsOfType<Rigidbody2D>())
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }

            foreach (Animator anim in FindObjectsOfType<Animator>())
            {
                if (anim.updateMode == AnimatorUpdateMode.UnscaledTime) return;

                anim.speed = 0;
            }
        }
    }
}
