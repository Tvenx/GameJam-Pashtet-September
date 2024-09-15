using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public GameObject _itemPrefab;
    public int _index;
    public string _name;
}