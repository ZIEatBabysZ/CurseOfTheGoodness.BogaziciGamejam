using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour , Interactable
{
    public Items burningMatch;
    public InventoryManager inventoryManager;
    public InGameText ingameText;
    public InfoPanel infoPanel;


    private void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
        ingameText = GameObject.FindGameObjectWithTag("InGameText").GetComponent<InGameText>();
        infoPanel = GameObject.FindGameObjectWithTag("InfoWrapper").GetComponent<InfoPanel>();
    }

    public void Interact()
    {
        var result = inventoryManager.items.Find(o => o.itemName == "Kibrit");
        if(result == null)
        {
            ingameText.ShowErrorText();
            return;
        }
        else
        {
            inventoryManager.items.Remove(result);
            inventoryManager.items.Add(burningMatch);
            inventoryManager.RefreshSlots();
            infoPanel.OpenInfoPanel("Yanan kibrit alýndý!");
        }
    }
 
}
