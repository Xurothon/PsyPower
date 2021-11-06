using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Button))]
public class PowerButton : MonoBehaviour
{
    [SerializeField] private Text _costText;
    [SerializeField] private int _cost;
    private Image _image;
    private Button _button;
    private int _id;
    private PowerShop _powerShop;

    public void Init(PowerShop powerShop, int id)
    {
        _powerShop = powerShop;
        _id = id;
    }

    public void SmearButton()
    {
        Color newColor = _image.color;
        newColor.a = 0.2f;
        _image.color = newColor;
    }

    public void ChooseButton()
    {
        Color newColor = _image.color;
        newColor.a = 0.8f;
        _image.color = newColor;
    }

    public void ActiveButton(int id)
    {
        _costText.gameObject.SetActive(false);
    }

    public int GetCost()
    {
        return _cost;
    }

    private void AddListener()
    {
        _button.onClick.AddListener(() => _powerShop.ActiveOrBuy(this, _id));
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
        _costText.text = _cost.ToString();
        AddListener();
    }
}
