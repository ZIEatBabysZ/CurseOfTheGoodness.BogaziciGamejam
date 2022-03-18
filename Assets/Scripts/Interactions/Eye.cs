using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour, Interactable
{
    public InventoryManager inventoryManager;
    public GameObject koylukadin;
    public InfoPanel infoPanel;
    public Items eye;


    private void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
        infoPanel = GameObject.FindGameObjectWithTag("InfoWrapper").GetComponent<InfoPanel>();
    }



    public void Interact()
    {
        inventoryManager.items.Add(eye);
        inventoryManager.RefreshSlots();
        koylukadin.gameObject.SetActive(true);
        infoPanel.OpenInfoPanel("Göz envantere eklendi!");
        Destroy(gameObject);
    }



}
