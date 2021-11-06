using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdHelper : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private Button _continueStepButton;
    [SerializeField] private Button _x2CoinsButton;
    [SerializeField] private Button _addCoinsButton;
    [SerializeField] private int _addCoinsCount;
    private string _placementAddCoins = "AddCoins";
    private string _placementContinueStep = "ContinueStep";
    private string _placementx2Coins = "x2Coins";
    private string _placementLevelComplete = "LevelComplete";

    public void OnUnityAdsDidError(string message) { }

    public void OnUnityAdsDidStart(string placementId) { }

    public void OnUnityAdsReady(string placementId) { }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == _placementAddCoins)
        {
            if (showResult == ShowResult.Finished)
            {
                DataWorker.Instance.AddCoins(_addCoinsCount);
            }
        }
        else if (placementId == _placementContinueStep)
        {
            if (showResult == ShowResult.Finished)
            {
                Helpers.Instance.PositionChanger.ResetCurrentStep();
                Helpers.Instance.ManaTracker.ResetMana();
                Helpers.Instance.UIHelper.DisableGameOverPanel();
            }
        }
        else if (placementId == _placementx2Coins)
        {
            if (showResult == ShowResult.Finished)
            {
                DataWorker.Instance.AddCoins(Helpers.Instance.CoinsCounter.StepCoinsCount);
                Helpers.Instance.LevelLoader.LoadNextLevel();
            }
        }
    }

    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

    public void ShowLevelCompleteAd()
    {
        ShowPlacement(_placementLevelComplete);
    }

    private void ShowPlacement(string placementName)
    {
        if (Advertisement.IsReady(placementName))
            Advertisement.Show(placementName);
    }

    private void Awake()
    {
        _addCoinsButton.onClick.AddListener(() => ShowPlacement(_placementAddCoins));
        _continueStepButton.onClick.AddListener(() => ShowPlacement(_placementContinueStep));
        _x2CoinsButton.onClick.AddListener(() => ShowPlacement(_placementx2Coins));
    }

    private void Start()
    {
        Advertisement.AddListener(this);
        if (Advertisement.isSupported)
            Advertisement.Initialize("4038207", false);
    }
}
