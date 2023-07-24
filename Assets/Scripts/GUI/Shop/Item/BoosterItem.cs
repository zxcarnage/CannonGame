using UnityEngine;

public class BoosterItem : ShopItem
{
    [SerializeField] private Booster _booster;
    
    public Booster Booster => _booster;
}