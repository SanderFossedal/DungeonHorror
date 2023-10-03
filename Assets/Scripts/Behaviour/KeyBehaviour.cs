using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{

    [SerializeField] InventoryManager.AllItems itemType;

    public void PickUp()
    {
        
        InventoryManager.Instance.AddItem(itemType);
        Destroy(gameObject);
    }
}
