using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private ItemIformation _itemIformation;
    
    public ItemIformation Information => _itemIformation;
}