using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] private List<Item> savedItems = new List<Item>();
    string data = "";

    private void Start()
    {
       // PlayerPrefs.DeleteAll();
         data = PlayerPrefs.GetString("Items");

        if (data != null)
        {
            foreach (char i in data)
            {
                int bar = i - '0';
                items.Add(savedItems[bar]);
            }
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ItemObject>() != null)
        {
            items.Add(other.GetComponent<ItemObject>().GetItem());
            Destroy(other.gameObject);
            Debug.Log("Item added to inventory: " + other.GetComponent<ItemObject>().GetItem()._index);
            
            data = data + other.GetComponent<ItemObject>().GetItem()._index;

            PlayerPrefs.SetString("Items", data);
            Debug.Log(PlayerPrefs.GetString("Items"));
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
           // Debug.Log("Item added to inventory: " + item._index);
           
        }
    }

}
