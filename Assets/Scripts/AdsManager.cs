using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsShowListener, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId = "5312717";
    [SerializeField] string _iOSGameId = "5312716";
    [SerializeField] bool _testMode = true;
    private string _gameId;
 
    void Awake()
    {
        InitializeAds();
    }
 
    public void InitializeAds()
    {
#if UNITY_IOS
            _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#elif UNITY_EDITOR
            _gameId = _androidGameId; //Only for testing the functionality in the Editor
#endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
    }

    public void PlayAd()
    {
        if (PlayerPrefs.GetInt("isAdvOn") == 1)
        {
            Advertisement.Show("Interstitial_Android", this);
        }
        else
        {
            Debug.Log("Advertisements are off.");
        }

    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }
 
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    // Implement the interface methods
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Ad show failed: " + error.ToString() + " - " + message);
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Ad show started");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Ad clicked");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            Debug.Log("Ad completed");
            // Provide rewards or perform any necessary actions after ad completion
        }
        else if (showCompletionState == UnityAdsShowCompletionState.SKIPPED)
        {
            Debug.Log("Ad skipped");
            // Handle the case when the ad was skipped by the user
        }
    }
}