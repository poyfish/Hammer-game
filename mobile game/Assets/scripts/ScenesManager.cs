using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public Animator Fade;
    public float FadeTime;

    string nextScene;

    private void Awake()
    {
        SceneManager.activeSceneChanged += OnSceneChange;
    }

    public void GoToSceneFade(string SceneName)
    {
        nextScene = SceneName;

        Fade.speed = FadeTime;

        Fade.CrossFade("FadeIn", 0, 0);

        Invoke("GoToScene", FadeTime);
    }

    public void GoToSceneFadeOut(string SceneName)
    {
        nextScene = SceneName;

        Fade.speed = FadeTime;

        GoToScene();
    }

    public void GoToScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void OnSceneChange(Scene current, Scene next)
    {
        Fade.CrossFade("FadeOut",0,0);
    }
}
