using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{

    public Item item;

    void Start()
    {
        Debug.Log("This items name is" + item.itemName);
        
    }
}
