using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class InteractableObject : MonoBehaviour
{
    public bool playerInRange;
 
    public string ItemName;
 
 
    public string GetItemName()
    {
 
        return ItemName;
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerInRange && SelectionManager.Instance.OnTarget &&
         SelectionManager.Instance.selectedObject == this.gameObject)
        {
 
            /*Debug.Log("Item added to Inventory");
            Destroy(gameObject);*/
            
            if (!InventorySystem.Instance.CheckIfFull())
            {
                if (SelectionManager.Instance.selectedObject != null)
 
 
                {
                    InventorySystem.Instance.AddToInventory(ItemName);
                    Debug.Log("Item added to Inventory");
                    Destroy(gameObject);
                    
                }
                else
                {
                    Debug.Log("inventory is full!");
                }
            }
 
        }
 
    }
 
 
 
 
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
}