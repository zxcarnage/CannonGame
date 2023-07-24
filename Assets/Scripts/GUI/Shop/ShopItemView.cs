using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Button _sellButton;

    public event Action<int,Booster, ShopItemView> OnSellButtonClicked;

    private Booster _booster;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Render(BoosterItem item)
    {
        _icon.sprite = item.Information.Icon;
        _description.text = item.Information.Description;
        _label.text = item.Information.Name;
        _price.text = Convert.ToString(item.Information.Price);
        _booster = item.Booster;
    }

    public void Lock()
    {
        _sellButton.interactable = false;
        _label.text = "Sold";
        _description.text = "Sold";
    }

    private void OnButtonClick()
    {
        var price = Convert.ToInt16(_price.text);
        OnSellButtonClicked?.Invoke(price, _booster, this);
    }
    
}
