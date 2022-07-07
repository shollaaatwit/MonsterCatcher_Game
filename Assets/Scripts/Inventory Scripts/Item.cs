using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public bool isSelected {get; set;}

    public int amount;
    public string title;
    public int id;

    //constructor for item, returns found item's id
    public Item(int id)
    {
        this.id = id;
    }


    // Organized Dictionary of items by ID
    public Dictionary<int, ItemInfo> itemTypes = new Dictionary<int, ItemInfo>()
    {
        {0, null},
        {1, new ItemInfo(ItemAssets.Instance.pumpkinSeedSprite){itemType = ItemInfo.ItemType.Seed,
                                                                seedPrefab = ItemAssets.Instance.pumpkinSeed}},

        {2, new ItemInfo(ItemAssets.Instance.stickSprite){itemType = ItemInfo.ItemType.Tool,
                                                            toolPrefab = ItemAssets.Instance.stickTool}},
    };


    public Sprite GetSprite(int myKey)
    {
        return itemTypes[myKey]?.itemSprite;
    }

}
