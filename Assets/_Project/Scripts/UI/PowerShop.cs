using UnityEngine;

public class PowerShop : MonoBehaviour
{
    [SerializeField] private PowerButton[] _powerButtons;

    public void ChooseStartButton()
    {
        _powerButtons[DataWorker.Instance.ChoosePower].ChooseButton();
    }

    public int GetPowerCount()
    {
        return _powerButtons.Length;
    }

    public void ActiveOrBuy(PowerButton button, int idPower)
    {
        if (DataWorker.Instance.Powers[idPower] == 1)
        {
            ChooseButton(button, idPower);
        }
        else
        {
            TryBuy(button, idPower);
        }
    }

    private void SmearButtons()
    {
        for (int i = 0; i < _powerButtons.Length; i++)
        {
            _powerButtons[i].SmearButton();
        }
    }

    private void ChooseButton(PowerButton button, int idPower)
    {
        Helpers.Instance.SphereCreater.ChangeIdPower(idPower);
        Helpers.Instance.UIHelper.DisableShopPanel();
        SmearButtons();
        button.ChooseButton();
    }

    private void TryBuy(PowerButton button, int idPower)
    {
        if (DataWorker.Instance.Coins >= button.GetCost())
        {
            DataWorker.Instance.DeductCoins(button.GetCost());
            DataWorker.Instance.SavePowerAfterBuy(idPower);
            button.ActiveButton(idPower);
            ChooseButton(button, idPower);
        }
    }

    private void ActiveBottons()
    {
        for (int i = 0; i < _powerButtons.Length; i++)
        {
            _powerButtons[i].Init(this, i);
            if (DataWorker.Instance.Powers[i] == 1)
            {
                _powerButtons[i].ActiveButton(i);
            }

        }
    }

    private void Start()
    {
        ChooseStartButton();
        ActiveBottons();
    }
}
