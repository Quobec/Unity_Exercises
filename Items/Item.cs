using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="Items/Create New Item")]


public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public string itemDesc;
    public Sprite icon;
    public int xSize;
    public int ySize;

}
