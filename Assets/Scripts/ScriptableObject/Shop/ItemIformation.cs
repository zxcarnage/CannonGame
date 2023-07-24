using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Item Information", fileName = "New Item Information", order = 0)]
public class ItemIformation : ScriptableObject
{
    public Sprite Icon;
    public string Name;
    public string Description;
    public int Price;
}