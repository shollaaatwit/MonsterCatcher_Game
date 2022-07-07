using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo
{
    public Sprite itemSprite;
    public ItemInfo(Sprite itemSprite)
    {
        this.itemSprite = itemSprite;
    }
    public enum ItemType
    {
        Plant,
        Seed,
        Tool,
        Tomato,
        Pumpkin,
    }

    public GameObject seedPrefab;
    public GameObject toolPrefab;
    public ItemType itemType;
}
