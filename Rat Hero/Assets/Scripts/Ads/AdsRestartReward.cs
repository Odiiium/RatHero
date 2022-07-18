using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdsRestartReward : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private readonly static string androidAdID = "Rewarded_Android";

    private string adID;

    internal static bool isAdWatched = false;

    [SerializeField] GameObject postGameUI;
    [SerializeField] GameObject gameUI;

    private void OnEnable()
    {
        adID = androidAdID;
        LoadAd();
    }

    public void LoadAd()
    {
        Advertisement.Load(adID, this);
    }

    internal void ShowAd()
    {
        if (!isAdWatched)
        {
            Advertisement.Show(adID, this);
            LoadAd();
        }
    }

    private void AddOneLiveForCharacter()
    {
        isAdWatched = true;
        ShowGameUI();
        HealthBar.healthPoints = HealthBar.maximumHealth;
        ManaBar.mana = ManaBar.maximumMana;
        PauseMenu.isGame = true;
        Character.onHealthChanged?.Invoke();
        Character.onManaChanged?.Invoke();
    }

    private void ShowGameUI()
    {
        gameUI.gameObject.SetActive(true);
        postGameUI.gameObject.SetActive(false);
    }
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(adID) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            AddOneLiveForCharacter();
        }
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
    }
    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
    }
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }
    public void OnUnityAdsShowStart(string placementId)
    {
    }
    public void OnUnityAdsShowClick(string placementId)
    {
    }
}
