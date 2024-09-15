using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ItemObject>() != null)
        {
            items.Add(other.GetComponent<ItemObject>().GetItem());
            Destroy(other.gameObject);
            Debug.Log("Item added to inventory: " + other.GetComponent<ItemObject>().GetItem()._index);
        }
    }

    public void UseItem(int itemIndex, ItemPedestal pedestal)
    {
        Item itemToUse = items.Find(item => item._index == itemIndex);
        if (itemToUse != null)
        {
            pedestal.PlaceItem(itemToUse);
            items.Remove(itemToUse);
            Debug.Log("Item used from inventory: " + itemIndex);
        }
    }

    public void AddItem(Item item)
    {
        if (item != null)
        {
            items.Add(item);
            Debug.Log("Item added to inventory: " + item._index);
        }
    }

}
