using UnityEngine;
using UnityEngine.UI;

public class SphereCreater : MonoBehaviour
{
    [SerializeField] private GameObject[] _powerPrefabs;
    [SerializeField] private Sprite[] _powerSprites;
    [SerializeField] private Image _currentSprite;
    [SerializeField] private int _currentIdPower;

    public void ChangeIdPower(int id)
    {
        _currentIdPower = id;
        DataWorker.Instance.ChangeChoosePower(id);
        ChangePowerImage();
    }

    public void CreatePowerSphere(int id)
    {
        if (id == _currentIdPower)
        {
            while (!Helpers.Instance.EnemySelector.IsEmpty)
            {
                Helpers.Instance.ManaTracker.DeductMana();
                GameObject power = Instantiate(_powerPrefabs[_currentIdPower]);
                power.transform.position = Helpers.Instance.EnemySelector.GetObjectTransform().position;
                PowerSphere powerSphere = power.GetComponent<PowerSphere>();
                powerSphere.IncreaseAbility(DataWorker.Instance.GetAddRadius(), DataWorker.Instance.GetAddForce());
                Destroy(power, 5f);
            }
        }
    }

    private void ChangePowerImage()
    {
        _currentIdPower = DataWorker.Instance.ChoosePower;
        _currentSprite.sprite = _powerSprites[_currentIdPower];
        _currentSprite.SetNativeSize();
        _currentSprite.rectTransform.sizeDelta = _currentSprite.rectTransform.sizeDelta / 1000;
    }

    private void Start()
    {
        ChangePowerImage();
    }
}
