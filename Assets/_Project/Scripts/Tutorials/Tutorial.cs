using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static Tutorial Instance { get; private set; }
    [SerializeField] private GameObject _firstTutorial;
    [SerializeField] private GameObject _secondTutorial;
    private bool _isFirstTutorialComplete;
    private bool _isSecondTutorialComplete;

    public void CompleteFirstTutorial()
    {
        if (!_isFirstTutorialComplete)
        {
            _isFirstTutorialComplete = true;
            DisableFirstTutorial();
            ActiveSecondTutorial();
        }
    }

    public void CompleteSecondTutorial()
    {
        if (!_isSecondTutorialComplete)
        {
            _isSecondTutorialComplete = true;
            DisableSecondTutorial();
        }
    }

    private void DisableFirstTutorial()
    {
        _firstTutorial.SetActive(false);
    }

    private void ActiveSecondTutorial()
    {
        _secondTutorial.SetActive(true);
    }

    private void DisableSecondTutorial()
    {
        _secondTutorial.SetActive(false);
        DataWorker.Instance.SaveTutorialComplete();
    }

    private void Start()
    {
        if (DataWorker.Instance.IsTutorialsComplete)
        {
            _isFirstTutorialComplete = true;
            _isSecondTutorialComplete = true;
        }
        else
        {
            _firstTutorial.SetActive(true);
        }
    }

    private void Awake()
    {
        Instance = this;
    }
}
