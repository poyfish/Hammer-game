using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 OriginalPosition;
    void Start()
    {
        OriginalPosition = transform.position;
    }

    public void Shake(int cycles, float force, float interval)
    {
        StartCoroutine(IShake(cycles, force, interval));
    }

    IEnumerator IShake(int cycles, float force, float interval)
    {
        yield return null;

        for (int i = 0; i < cycles; i++)
        {
            transform.position = OriginalPosition + new Vector3(Random.Range(-force, force), Random.Range(-force, force));

            yield return new WaitForSeconds(interval);
        }

        transform.position = OriginalPosition;
    }
}
