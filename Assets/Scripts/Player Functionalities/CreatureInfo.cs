using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureInfo
{
    public Sprite creatureSprite;
    public GameObject creaturePrefab;


    public enum CreatureDestination
    {
        Party,
        Inventory,
    }

    public CreatureDestination creatureDest;
    
    public CreatureInfo(Sprite creatureSprite, GameObject creaturePrefab)
    {
        this.creatureSprite = creatureSprite;
        this.creaturePrefab = creaturePrefab;
    }

}
