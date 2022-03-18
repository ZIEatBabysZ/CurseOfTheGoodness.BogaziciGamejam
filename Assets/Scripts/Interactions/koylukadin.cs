using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koylukadin : MonoBehaviour
{

    public InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
    }
    public void removeEyeFromUser()
    {
        if (PlayerPrefs.HasKey("eyeGiven"))
        {
           var result =  inventoryManager.items.Find(o => o.itemName == "Eye");
            if(result != null) { 
            inventoryManager.items.Remove(result);
            }
        }
    }
}
