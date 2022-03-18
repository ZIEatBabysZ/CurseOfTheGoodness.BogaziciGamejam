using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Item/New")]
public class Items : ScriptableObject
{
    public GameObject prefab;
    public string itemName;
    public Sprite icon;
    public bool requireItem;
    
}
