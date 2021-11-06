using UnityEngine;
using UnityEngine.UI;

public class UIHelper : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _staffShopButton;
    [SerializeField] private Button _radiusUpButton;
    [SerializeField] private Button _forceUpButton;
    [SerializeField] private Button _homeFromShopButton;
    [SerializeField] private GameObject _nextLevelButton;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _levelCompletePanel;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private TimeScaler _timeScaler;
    [SerializeField] private Text _levelNumberText;


    public void ActiveGameOverPanel()
    {
        this.Wait(0.5f, () => _gameOverPanel.SetActive(true));
    }

    public void ActiveLevelCompletPanel()
    {
        Helpers.Instance.AdHelper.ShowLevelCompleteAd();
        _levelCompletePanel.SetActive(true);
        this.Wait(2f, () => _nextLevelButton.SetActive(true));
    }

    public void DisableShopPanel()
    {
        _shopPanel.SetActive(false);
        _mainPanel.SetActive(true);
    }

    public void DisableGameOverPanel()
    {
        _gameOverPanel.SetActive(false);
    }

    private void AddButtonListener()
    {
        _playButton.onClick.AddListener(ActiveGame);
        _shopButton.onClick.AddListener(ActiveShopPanel);
        _radiusUpButton.onClick.AddListener(TryBuyRadiusUp);
        _forceUpButton.onClick.AddListener(TryBuyForceUp);
        _staffShopButton.onClick.AddListener(OpenStaffShop);
        _homeFromShopButton.onClick.AddListener(DisableShopPanel);
    }

    private void ActiveShopPanel()
    {
        _shopPanel.SetActive(true);
        _mainPanel.SetActive(false);
    }

    private void TryBuyRadiusUp()
    {
        if (Helpers.Instance.AbilityPriceList.IsBuyRadiusUp())
        {
            DataWorker.Instance.UpRadiusULevel();
        }
    }

    private void TryBuyForceUp()
    {
        if (Helpers.Instance.AbilityPriceList.IsBuyForceUp())
        {
            DataWorker.Instance.UpForceUpLevel();
        }
    }

    private void ActiveButton(Button button)
    {
        Image buttonImage = button.GetComponent<Image>();
        Color newColor = buttonImage.color;
        newColor.a = 0.8f;
        buttonImage.color = newColor;
    }

    private void ActiveGame()
    {
        _mainPanel.SetActive(false);
        Helpers.Instance.PositionChanger.ActiveEnemyMove();
    }

    private void OpenStaffShop()
    {
        Helpers.Instance.LevelLoader.OpenStaffShop();
    }

    private void RestartInPausePanel()
    {
        _timeScaler.TimeScalerUp();
        Helpers.Instance.LevelLoader.RestartLevel();
    }

    private void Start()
    {
        _shopPanel.SetActive(false);
        _levelNumberText.text = "Level " + (DataWorker.Instance.CurrentLevel + 1);
    }

    private void Awake()
    {
        AddButtonListener();
    }
}
