using UnityEngine;

public class DataWorker : MonoBehaviour
{
    public static DataWorker Instance { get; private set; }
    public int Coins { get; private set; }
    public int ForceUpLevel { get; private set; }
    public int RadiusUpLevel { get; private set; }
    public int ChooseBat { get; private set; }
    public int ChoosePower { get; private set; }
    public int CurrentLevel { get; private set; }
    public int[] Powers { get; private set; }
    public bool IsTutorialsComplete
    {
        get
        {
            return _tutorials == _tutorialComplete;
        }
    }
    [SerializeField] private float _forceStep;
    [SerializeField] private float _radiusStep;
    private int _tutorials;
    private const int _tutorialComplete = 1;

    public void UpdateCountCoins(int value)
    {
        Coins = value;
    }

    public void ChangeChoosePower(int id)
    {
        ChoosePower = id;
    }

    public void DeductCoins(int value)
    {
        Coins -= value;
        Helpers.Instance.CoinsCounter.UpdateCoinsCount(Coins);
    }

    public void AddCoins(int value)
    {
        Coins += value;
        Helpers.Instance.CoinsCounter.UpdateCoinsCount(Coins);
    }

    public void UpForceUpLevel()
    {
        ForceUpLevel++;
    }
    public void UpRadiusULevel()
    {
        RadiusUpLevel++;
    }

    public void SavePowerAfterBuy(int powerId)
    {
        Powers[powerId] = 1;
        SaveValue(PlayerPrefsKeys.POWER.ToString() + powerId, 1);
    }

    public void SaveChooseStaff(int id)
    {
        ChooseBat = id;
        SaveValue(PlayerPrefsKeys.CHOOSE_STAFF, ChooseBat);
    }

    public void IncrementCurrentLevel()
    {
        CurrentLevel++;
    }

    public float GetAddForce()
    {
        return ForceUpLevel * _forceStep;
    }

    public float GetAddRadius()
    {
        return RadiusUpLevel * _radiusStep;
    }

    public void SaveTutorialComplete()
    {
        SaveValue(PlayerPrefsKeys.TUTORIALS, _tutorialComplete);
    }

    private void ReadAllPlayerPrefs()
    {
        ReadPowerInfo();
        Coins = GetValue(PlayerPrefsKeys.COINS);
        ForceUpLevel = GetValue(PlayerPrefsKeys.FORCE_UP_LEVEL);
        RadiusUpLevel = GetValue(PlayerPrefsKeys.RADIUS_UP_LEVEL);
        ChoosePower = GetValue(PlayerPrefsKeys.CHOOSE_POWER);
        CurrentLevel = GetValue(PlayerPrefsKeys.CURRENT_LEVEL);
        _tutorials = GetValue(PlayerPrefsKeys.TUTORIALS);
    }

    private void ReadPowerInfo()
    {
        int count = Helpers.Instance.PowerShop.GetPowerCount();
        Powers = new int[count];
        if (PlayerPrefs.HasKey(PlayerPrefsKeys.POWER.ToString() + "0"))
        {
            for (int i = 0; i < count; i++)
            {
                Powers[i] = GetValue(PlayerPrefsKeys.POWER.ToString() + i);
            }
        }
        else
        {
            SavePowerAfterBuy(0);
            for (int i = 1; i < count; i++)
            {
                SaveValue(PlayerPrefsKeys.POWER.ToString() + i, 0);
            }
        }
    }

    private int GetValue(PlayerPrefsKeys playerPrefsKey)
    {
        if (PlayerPrefs.HasKey(playerPrefsKey.ToString()))
        {
            return PlayerPrefs.GetInt(playerPrefsKey.ToString());
        }
        return 0;
    }

    private int GetValue(string playerPrefsKeyString)
    {
        if (PlayerPrefs.HasKey(playerPrefsKeyString))
        {
            return PlayerPrefs.GetInt(playerPrefsKeyString);
        }
        return 0;
    }

    private void SaveValue(PlayerPrefsKeys playerPrefsKey, int value)
    {
        PlayerPrefs.SetInt(playerPrefsKey.ToString(), value);
    }

    private void SaveValue(string playerPrefsKeyString, int value)
    {
        PlayerPrefs.SetInt(playerPrefsKeyString, value);
    }

    private void Awake()
    {
        Instance = this;
        ReadAllPlayerPrefs();
    }

    private void OnDisable()
    {
        SaveValue(PlayerPrefsKeys.COINS, Coins);
        SaveValue(PlayerPrefsKeys.FORCE_UP_LEVEL, ForceUpLevel);
        SaveValue(PlayerPrefsKeys.RADIUS_UP_LEVEL, RadiusUpLevel);
        SaveValue(PlayerPrefsKeys.CHOOSE_POWER, ChoosePower);
        SaveValue(PlayerPrefsKeys.CURRENT_LEVEL, CurrentLevel);
    }
}
