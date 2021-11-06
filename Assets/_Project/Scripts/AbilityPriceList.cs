using UnityEngine;
using UnityEngine.UI;

public class AbilityPriceList : MonoBehaviour
{
    [SerializeField] private int _radiusUpCost;
    [SerializeField] private int _maxRadiusUpLevel;
    [SerializeField] private Text _radiusUpCostText;
    [SerializeField] private int _forceUpCost;
    [SerializeField] private int _maxforceUpLevel;
    [SerializeField] private Text _forceUpCostText;


    public bool IsBuyRadiusUp()
    {
        if (DataWorker.Instance.RadiusUpLevel < _maxRadiusUpLevel)
        {
            if (DataWorker.Instance.Coins >= _radiusUpCost)
            {
                DataWorker.Instance.DeductCoins(_radiusUpCost);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool IsBuyForceUp()
    {
        if (DataWorker.Instance.ForceUpLevel < _maxforceUpLevel)
        {
            if (DataWorker.Instance.Coins >= _forceUpCost)
            {
                DataWorker.Instance.DeductCoins(_forceUpCost);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    private void Awake()
    {
        _radiusUpCostText.text = _radiusUpCost.ToString();
        _forceUpCostText.text = _forceUpCost.ToString();
    }
}
