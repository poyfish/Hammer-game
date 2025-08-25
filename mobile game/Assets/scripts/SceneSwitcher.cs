using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public string SceneName;

    public void SwitchScene()
    {
        Systems.ScenesManager.GoToSceneFade(SceneName);
    }
}
