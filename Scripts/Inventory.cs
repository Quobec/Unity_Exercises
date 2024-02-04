using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject InventoryContentObject;
    public List<GameObject>    InventoryList;
    public int InventoryColumns;
    public int InventoryRows;
    private GameObject[,] InventorySlots = new GameObject[0,0];
    private bool[,] InventorySlotsFree = new bool[0,0];

    public Item flashlight;

    void Update(){
        if(Input.GetKeyUp(KeyCode.Alpha1)){
            InventoryList.Clear();
            InventoryColumns =  Mathf.CeilToInt((float)InventoryContentObject.GetComponent<RectTransform>().childCount/4);
            InventorySlots = new GameObject [InventoryColumns,InventoryRows];
            InventorySlotsFree = new bool [InventoryColumns*2,InventoryRows*2];

            for (int i = 0; i < InventoryContentObject.GetComponent<RectTransform>().childCount; i++)
            {
                InventoryList.Add(InventoryContentObject.GetComponent<RectTransform>().GetChild(i).gameObject);
            }
            for (int x = 0; x < InventoryColumns*2; x++)
            {
                for (int y = 0; y < InventoryRows*2; y++)
                {
                    InventorySlotsFree[x,y] = false;
                }   
            }

            int index = 0;
            for (int x = 0; x < InventoryColumns; x++)
            {
                for (int y = 0; y < InventoryRows; y++)
                {
                    if(index < InventoryList.Count){
                        InventorySlots[x,y] = InventoryList[index];
                        InventorySlotsFree[x,y] = true;
                        index++;
                        InventorySlots[x,y].GetComponent<RectTransform>().Find("Text").GetComponent<Text>().text = x + "," + y; 
                    }
                }   
            }
            InventorySlotsFree[1,1] = false;
            InventorySlotsFree[2,2] = false;
            InventorySlots[1,1].GetComponent<Image>().color = Color.red;
            InventorySlots[2,2].GetComponent<Image>().color = Color.red;
        }

        if(Input.GetKeyUp(KeyCode.Alpha2)){
            PickUpItem();
        }
    }

    void PickUpItem() {
        for (int x = 0; x < InventoryColumns; x++)
        {
            for (int y = 0; y < InventoryRows; y++)
            {
                if( InventorySlotsFree[x,y] == true && InventorySlotsFree[x+flashlight.xSize-1,y+flashlight.ySize-1] == true){
                    InventorySlotsFree[x,y] = false;
                    InventorySlotsFree[x+flashlight.xSize-1,y+flashlight.ySize-1] = false;
                    InventorySlots[x,y].GetComponent<Image>().color = Color.red;
                    InventorySlots[x+flashlight.xSize-1,y+flashlight.ySize-1].GetComponent<Image>().color = Color.red;
                    Debug.Log((x+flashlight.xSize-1).ToString()+ "," + (y+flashlight.ySize-1).ToString());
                    return;
                }
            }   
        }
    }
}