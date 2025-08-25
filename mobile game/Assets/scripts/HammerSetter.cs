using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSetter : MonoBehaviour
{
    public HammerObject Hammer;


    public void SetHammer(HammerObject hammer)
    {
        Systems.HammerManager.SwitchHammer(hammer);
    }
}
