using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public Animator Fade;
    public float FadeTime;
    public float TransitionDelay;

    string nextScene;

    private void Start()
    {
        SceneManager.activeSceneChanged += OnSceneChange;
    }

    public void GoToSceneFade(string SceneName)
    {
        nextScene = SceneName;

        Fade.speed = FadeTime;

        FadeIn();

        Invoke("GoToScene", TransitionDelay);
    }

    public void GoToScene(string SceneName)
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
        Invoke("FadeOut", .05f);
    }

    public void FadeOut()
    {
        Fade.CrossFade("FadeOut", 0, 0);
    }

    public void FadeIn()
    {
        Fade.CrossFade("FadeIn", 0, 0);
    }
}
