using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    public List<Items> items;
    public GameObject[] itemHolders;
    public Items paper;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("InventoryManager");
        if(objs.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
 
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("LetterRead"))
        {
            if (PlayerPrefs.HasKey("LetterBurned"))
            {

            }
            else
            {
                    var result = items.Find(o => o.itemName == paper.itemName);
                    if (result == null)
                    {
                        items.Add(new Items { prefab = paper.prefab, icon = paper.icon, requireItem = paper.requireItem, itemName = paper.itemName });
                    RefreshSlots();
                    }
            }
        }
    }




    public void RefreshSlots()
    {
        itemHolders = GameObject.FindGameObjectsWithTag("ItemHolder");

        if (items.Count != 0)
        {
            for (int i = 0; i < items.Count; i++)
            {
             
                itemHolders[i].GetComponent<Image>().sprite = items[i].icon;


            }

        }
        else
        {
            foreach(var obj in itemHolders)
            {
                obj.GetComponent<Image>().sprite =  null;
                obj.GetComponent<Image>().color = Color.white;
            }
           
        }

    }
}
