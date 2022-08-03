using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creatures : MonoBehaviour
{
    public string creatureType;
    public int id;
    public int itemid;

    public static Creatures Instance;

    public Creatures(int id)
    {
        this.id = id;
    }
    public Creatures(int id, int itemid)
    {
        this.id = id;
        this.itemid = itemid;
    }
    // creature party system will reflect the inventory system

    public Dictionary<int, CreatureInfo> creatureTypes = new Dictionary<int, CreatureInfo>()
    {
        {0, null},
        {1, new CreatureInfo(CreatureAssets.Instance.dogSprite, CreatureAssets.Instance.dogPrefab)
                                                {creatureDest = CreatureInfo.CreatureDestination.Party}},
        {2, new CreatureInfo(CreatureAssets.Instance.fireflySprite, CreatureAssets.Instance.fireflyPrefab) 
                                                {creatureDest = CreatureInfo.CreatureDestination.Inventory}},
    };

    public Sprite GetSprite(int myKey)
    {
        return creatureTypes[myKey]?.creatureSprite; 
    }

}
