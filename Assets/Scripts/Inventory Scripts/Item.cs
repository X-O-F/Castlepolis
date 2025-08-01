using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{

    [Header("Only gameplay")]
    public TileBase tile;

    public ItemType itemType;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);


    [Header("Only UI")]
    public bool stackable = true;


    [Header("Both")]
    public Sprite image;

    public int itemID; // Add this line
}

public enum ItemType
{
    BuildingBlock,
    Tool,
    Weapon,
    Food
}

public enum ActionType
{
    Fight,
    Eat
}