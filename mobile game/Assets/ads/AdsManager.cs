using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsShowListener
{
    public string iosID;

    public string googleId;

    public bool TestMode;

    private string gameId;

    string androidAdUnitId = "Rewarded_Android";
    string iOSAdUnitId = "Rewarded_iOS";

    public UnityEvent OnAdComplete;

    string gameAdUnitId;

    void Awake()
    {
#if UNITY_IOS
        gameId = iosId;
#elif UNITY_ANDROID
        gameId = googleId;
#endif

#if UNITY_IOS
        gameAdUnitId = iOSAdUnitId;
#elif UNITY_ANDROID
        gameAdUnitId = androidAdUnitId;
#endif

        Advertisement.Initialize(gameId,TestMode, this);
    }

    public void PlayRewardAd()
    {
        if (!Advertisement.isInitialized) return;

        Advertisement.Show(gameAdUnitId, this);

        Time.timeScale = 0;
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        Time.timeScale = 1;

        if (adUnitId.Equals(gameAdUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            OnAdComplete.Invoke();
        }
    }



    public void OnInitializationComplete()
    {
        //Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

}
