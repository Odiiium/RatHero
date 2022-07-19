using UnityEngine;
using UnityEngine.Advertisements;
public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    internal string androidGameId = "4845568";
    internal string iOsGameId = "4845569";
    [SerializeField] bool testMode = true;

    private string gameID;

    private void Awake()
    {
        InitializeAds();
        AdsRestartReward.isAdWatched = false;
    }


    public void InitializeAds()
    {
        gameID = androidGameId;
        Advertisement.Initialize(gameID, testMode, this);
    }

    public void OnInitializationComplete()
    {
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
    }
}
