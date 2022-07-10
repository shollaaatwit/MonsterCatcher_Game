using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creatures : MonoBehaviour
{
    public string creatureType;
    public int id;

    public Creatures(int id)
    {
        this.id = id;
    }

    // creature party system will reflect the inventory system

    public Dictionary<int, CreatureInfo> creatureTypes = new Dictionary<int, CreatureInfo>()
    {
        {0, null},
        {1, new CreatureInfo(CreatureAssets.Instance.dogSprite, CreatureAssets.Instance.dogPrefab)},
    };

    public Sprite GetSprite(int myKey)
    {
        return creatureTypes[myKey]?.creatureSprite; 
    }

}
