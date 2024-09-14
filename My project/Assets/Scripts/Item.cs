using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public Sprite _sprite;
    public int _index;
    public string _name;
}
