using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsWatchReward : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private readonly static string androidAdID = "Rewarded_Android";

    private string adID;

    internal static bool isAdWatched = false;

    int cheeseAdded;
    Button watchAdsButton;

    private void Awake()
    {
        watchAdsButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        watchAdsButton.onClick.AddListener(ShowAd);
        adID = androidAdID;
        LoadAd();
    }
    private void OnDisable()
    {
        watchAdsButton.onClick.RemoveListener(ShowAd);
    }

    public void LoadAd()
    {
        Advertisement.Load(adID, this);
    }

    internal void ShowAd()
    {
        Advertisement.Show(adID, this);
        LoadAd();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(adID) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            AddCheeseForAdsWatched();
        }
    }

    private void AddCheeseForAdsWatched()
    {
        if (RatLevelUp.CurrentLvl < 30) cheeseAdded = (int)(Mathf.Pow(RatLevelUp.CurrentLvl, 1.7f) / 2f);
        else if (RatLevelUp.CurrentLvl < 80) cheeseAdded = (int)(Mathf.Pow(RatLevelUp.CurrentLvl, 1.7f) / 3);
        else cheeseAdded = (int)(Mathf.Pow(RatLevelUp.CurrentLvl, 1.7f) / 4);
        RefreshMoney(cheeseAdded);
    }

    private void RefreshMoney(int money)
    {
        Money.AddCheese(money);
        MoneyController.onMoneyShows?.Invoke();
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