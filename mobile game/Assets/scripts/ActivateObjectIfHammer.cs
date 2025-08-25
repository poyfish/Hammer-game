using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectIfHammer : MonoBehaviour
{
    public HammerObject Hammer;

    public GameObject Object;

    public void Update()
    {
        Object.SetActive(Systems.HammerManager.CurrentHammer.name == Hammer.name);
    }
}
