using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ItemObject>() != null)
        {
            items.Add(other.GetComponent<ItemObject>().GetItem());
            Destroy(other.gameObject);
        }
    }
}
