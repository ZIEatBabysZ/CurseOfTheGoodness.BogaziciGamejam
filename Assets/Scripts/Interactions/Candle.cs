using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour, Interactable
{
    public InventoryManager inventoryManager;
    public RuntimeAnimatorController fireAnimator;
    public InGameText inGameText;
    public InfoPanel infoPanel;
    public bool isBurned = false;
    public CharacterInfo player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInfo>();
        infoPanel = GameObject.FindGameObjectWithTag("InfoWrapper").GetComponent<InfoPanel>();
        inGameText = GameObject.FindGameObjectWithTag("InGameText").GetComponent<InGameText>();
        inventoryManager = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>();
    }



    public void Interact()
    {
        if(isBurned == false) { 
        var result = inventoryManager.items.Find(o => o.itemName == "Burning Match");
        if(result == null)
        {
            inGameText.ShowErrorText();
        }
        else
        {
            GetComponent<Animator>().runtimeAnimatorController = fireAnimator;
            isBurned = true;
            infoPanel.OpenInfoPanel("Mum Yakýldý!");
            player.candleCount++;
        }
        }
        else
        {
            infoPanel.OpenInfoPanel("Mumlar zaten yakýldý!");
        }
    }
}
