using System;
using UnityEngine;

public class ItemPedestal : MonoBehaviour
{
    [SerializeField] private Transform placementPoint;
    [SerializeField] private int requiredItemIndex;
    private GameObject currentItem;
    private bool playerInRange;

    public event Action OnCorrectItemPlaced;
    public event Action OnItemRemoved;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (currentItem == null)
            {
                // Попытка использовать предмет
                InventoryManager inventory = FindObjectOfType<InventoryManager>();
                if (inventory != null)
                {
                    inventory.UseItem(requiredItemIndex, this);
                }
            }
            else
            {
                // Возврат текущего предмета в инвентарь
               // ReturnItemToInventory();
            }
        }
    }

    public void PlaceItem(Item item)
    {
        if (currentItem == null && item._itemPrefab != null && item._index == requiredItemIndex)
        {
            currentItem = Instantiate(item._itemPrefab, placementPoint.position, placementPoint.rotation);
            currentItem.transform.SetParent(placementPoint);
            Debug.Log("Item placed on pedestal: " + item._index);
            OnCorrectItemPlaced?.Invoke();
        }
    }

    private void ReturnItemToInventory()
    {
        InventoryManager inventory = FindObjectOfType<InventoryManager>();
        if (inventory != null)
        {
            if (currentItem != null)
            {
                ItemObject itemObj = currentItem.GetComponent<ItemObject>();

                if (itemObj != null)
                {
                    inventory.AddItem(itemObj.GetItem());
                    Debug.Log("Item returned to inventory: " + itemObj.GetItem()._index);
                }
                else
                {
                    Debug.Log("ItemObject не найден на currentItem");
                }

                Destroy(currentItem);
                currentItem = null;
                OnItemRemoved?.Invoke();
            }  
        }
    }

    public bool HasCorrectItem()
    {
        return currentItem != null && currentItem.GetComponent<ItemObject>().GetItem()._index == requiredItemIndex;
    }
}