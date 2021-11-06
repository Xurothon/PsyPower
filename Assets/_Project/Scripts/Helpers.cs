using UnityEngine;

public class Helpers : MonoBehaviour
{
    public static Helpers Instance { get; private set; }
    public UIHelper UIHelper { get { return _uiHelper; } }
    public PositionChanger PositionChanger { get { return _positionChanger; } }
    public ManaTracker ManaTracker { get { return _manaTracker; } }
    public CoinsCounter CoinsCounter { get { return _coinsCounter; } }
    public AbilityPriceList AbilityPriceList { get { return _abilityPriceList; } }
    public PowerShop PowerShop { get { return _powerShop; } }
    public SphereCreater SphereCreater { get { return _sphereCreater; } }
    public EnemySelector EnemySelector { get { return _enemySelector; } }
    public LevelLoader LevelLoader { get { return _levelLoader; } }
    public SoundPlayer SoundPlayer { get { return _soundPlayer; } }
    public AdHelper AdHelper { get { return _adHelper; } }
    [SerializeField] private UIHelper _uiHelper;
    [SerializeField] private PositionChanger _positionChanger;
    [SerializeField] private ManaTracker _manaTracker;
    [SerializeField] private CoinsCounter _coinsCounter;
    [SerializeField] private AbilityPriceList _abilityPriceList;
    [SerializeField] private PowerShop _powerShop;
    [SerializeField] private SphereCreater _sphereCreater;
    [SerializeField] private EnemySelector _enemySelector;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private SoundPlayer _soundPlayer;
    [SerializeField] private AdHelper _adHelper;

    private void Awake()
    {
        Instance = this;
    }
}
