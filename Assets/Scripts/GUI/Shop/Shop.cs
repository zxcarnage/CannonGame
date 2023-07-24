using System;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<BoosterItem> _shopItems;
    [SerializeField] private ShopItemView _template;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private Player _player;

    private void Start()
    {
        for (int i = 0; i < _shopItems.Count; i++)
        {
            AddItem(_shopItems[i]);
        }
    }

    private void AddItem(BoosterItem item)
    {
        var view = Instantiate(_template, _itemContainer.transform);

        view.Render(item);
        view.OnSellButtonClicked += SellButtonClicked;
    }

    private void SellButtonClicked(int price, Booster booster, ShopItemView item)
    {
        if (TrySellBooster(price, booster))
            item.Lock();
    }

    private bool TrySellBooster(int price, Booster booster)
    {
        if (_player.TryBuy(price))
        {
            _player.AddBooster(booster);
            return true;
        }

        return false;
    }
}