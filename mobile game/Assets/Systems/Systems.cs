using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Systems : Singleton<Systems>
{
    public static HammerManager HammerManager;
    public static ScenesManager ScenesManager;
    public static ScoreManager ScoreManager;

    private void Awake()
    {
        if(!base.InitializeSingleton(this)) return;

        HammerManager = GetComponentInChildren<HammerManager>();
        ScenesManager = GetComponentInChildren<ScenesManager>();
        ScoreManager = GetComponentInChildren<ScoreManager>();
    }
}
