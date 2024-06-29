using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HammerManager : MonoBehaviour
{
    Hammer Hammer;

    public HammerObject DefaultHammer;

    public HammerObject[] Hammers;

    public HammerObject CurrentHammer;

    public string CurrentHammerSaveKey;

    private void Awake()
    {
        SceneManager.activeSceneChanged += OnSceneChange;

        if (!PlayerPrefs.HasKey(CurrentHammerSaveKey))
        {
            CurrentHammer = DefaultHammer;
        }
        else
        {
            CurrentHammer = Hammers.Where(H => H.name == PlayerPrefs.GetString(CurrentHammerSaveKey)).FirstOrDefault();
        }
    }

    public void SwitchHammer(HammerObject hammer)
    {
        CurrentHammer = hammer;

        PlayerPrefs.SetString(CurrentHammerSaveKey, hammer.name);
        PlayerPrefs.Save();
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
