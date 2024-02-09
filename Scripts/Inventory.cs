using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject InventoryContentObject;
    public List<GameObject>    InventoryList;
    private int InventoryColumns;
    public int InventoryRows;
    private GameObject[,] InventorySlots = new GameObject[0,0];
    private bool[,] InventorySlotsFree = new bool[0,0];

    public Item item;

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
                        ChangeSlotStatus(x,y,true, Color.white);
                    }
                }   
            }
            ChangeSlotStatus(1,1,false, Color.green);
            ChangeSlotStatus(3,2,false, Color.green);
            ChangeSlotStatus(2,3,false, Color.green);
        }

        if(Input.GetKeyUp(KeyCode.Alpha2)){
            PickUpItem(item);
        }

        if(Input.GetKeyUp(KeyCode.Tab)){
            this.gameObject.GetComponent<RectTransform>().Find("Viewport").gameObject.SetActive(!this.gameObject.GetComponent<RectTransform>().Find("Viewport").gameObject.activeSelf);
        }
    }

    void PickUpItem(Item item) {
        for (int x = 0; x < InventoryColumns; x++)
        {
            for (int y = 0; y < InventoryRows; y++)
            {
                bool isThereSpace = true;
                for (int i = 0; i < item.xSize; i++)
                {
                    for (int j = 0; j < item.ySize; j++)
                    {
                        if(InventorySlotsFree[x+i,y+j] == false){
                            isThereSpace = false;
                        }
                    }
                }
                if (isThereSpace)
                {
                    for (int i = 0; i < item.xSize; i++)
                    {
                        for (int j = 0; j < item.ySize; j++)
                        {
                            ChangeSlotStatus(x+i,y+j,false, Color.yellow);
                        }
                    }
                    return;
                } else {
                    isThereSpace = true;
                    for (int i = 0; i < item.ySize; i++)
                    {
                        for (int j = 0; j < item.xSize; j++)
                        {
                            //Debug.Log("X,Y:" +x+","+y+"|"+(x+i) +',' + (y+j) );
                            if(InventorySlotsFree[x+i,y+j] == false){
                                isThereSpace = false;
                            }
                        }
                    }
                    if(isThereSpace){
                        for (int i = 0; i < item.ySize; i++)
                        {
                            for (int j = 0; j < item.xSize; j++)
                            {
                                ChangeSlotStatus(x+i,y+j,false, Color.cyan);
                            }
                        }
                        return;
                    }
                }
            }   
        }
    }

    void ChangeSlotStatus(int x, int y, bool isFree, Color color){
        if(isFree){
            InventorySlotsFree[x,y] = true;
            InventorySlots[x,y].GetComponent<Image>().color = color;  
        } else {
            InventorySlotsFree[x,y] = false;
            InventorySlots[x,y].GetComponent<Image>().color = color;
        }
    }
}