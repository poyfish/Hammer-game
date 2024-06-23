using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HammerManager : MonoBehaviour
{
    Hammer Hammer;

    public HammerObject CurrentHammer;

    private void Awake()
    {
        SceneManager.activeSceneChanged += OnSceneChange;
    }

    public void SwitchHammer(HammerObject hammer)
    {
        CurrentHammer = hammer;
    }

    public void OnSceneChange(Scene current, Scene next)
    {
        Hammer = FindObjectOfType<Hammer>();

        if (Hammer != null)
        {
            Hammer.ChangeHammer(CurrentHammer);
        }
    }
}
