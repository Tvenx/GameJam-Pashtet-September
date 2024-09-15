using UnityEngine;

public class ItemPedestal : MonoBehaviour
{
    [SerializeField] private Transform placementPoint;
    [SerializeField] private int requiredItemIndex;
    private GameObject currentItem;
    private bool playerInRange;

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
                ReturnItemToInventory();
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
        }
    }

    private void ReturnItemToInventory()
    {
        InventoryManager inventory = FindObjectOfType<InventoryManager>();
        if (inventory != null)
        {
            Debug.Log("InventoryManager найден");
            if (currentItem != null)
            {
                Debug.Log("currentItem не равен null");
                ItemObject itemObj = currentItem.GetComponent<ItemObject>();

                if (itemObj != null)
                {
                    Debug.Log("ItemObject найден");
                    inventory.AddItem(itemObj.GetItem());
                    Debug.Log("Item returned to inventory: " + itemObj.GetItem()._index);
                }
                else
                {
                    Debug.Log("ItemObject не найден на currentItem");
                }

                Destroy(currentItem);
                currentItem = null;
            }
            else
            {
                Debug.Log("currentItem равен null");
            }
        }
        else
        {
            Debug.Log("InventoryManager не найден");
        }
    }


}