using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<AllItems> inventoryItems = new List<AllItems>();

    private void Awake()
    {
        Instance= this;
    }

    public void AddItem(AllItems item)
    {
        if(!inventoryItems.Contains(item))
        {
            inventoryItems.Add(item);
        }
    }

    public void RemoveItem(AllItems item)
    {
        if (inventoryItems.Contains(item))
        {
            inventoryItems.Remove(item);
        }
    }
    public enum AllItems
    {
        Key1, 
        Key2, 
        Key3
    }
}
