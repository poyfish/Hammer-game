using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectIfHammer : MonoBehaviour
{
    HammerManager hammerManager;

    public HammerObject Hammer;

    public GameObject Object;

    private void Start()
    {
        hammerManager = FindAnyObjectByType<HammerManager>();
    }

    public void Update()
    {
        Object.SetActive(hammerManager.CurrentHammer.name == Hammer.name);
    }
}
