using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSetter : MonoBehaviour
{
    HammerManager hammerManager;

    public HammerObject Hammer;

    private void Start()
    {
        hammerManager = FindAnyObjectByType<HammerManager>();
    }

    public void SetHammer(HammerObject hammer)
    {
        hammerManager.CurrentHammer = hammer;
    }
}
