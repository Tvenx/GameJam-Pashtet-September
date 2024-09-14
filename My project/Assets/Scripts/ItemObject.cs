using UnityEngine;

public class ItemObject : MonoBehaviour
{
   [SerializeField] private Item  _item;

    public Item GetItem()
    {
        return _item;
    }
}
