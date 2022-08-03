using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Catch : MonoBehaviour, IFunctionInteract
{
    /// <summary> Class that extends from IFunctionInteract interface and implements the UseTool method for the catch function. Can open potential for different catching skills or tools </summary>

    public void UseTool()
    {

        CatchCreature();

    }
    public int GetIDs()
    {

        return ReturnCreatureIds();

    }
    public bool IsCaught()
    {
        return caught;
    }

    public enum MyDestination
    {
        Party,
        Inventory,
    }

    public MyDestination dest;
    public CreatureSpawner creatureSpawner;
    public UnityEvent caughtMonster;
    public List<int> creatureIds = new List<int>();
    public Creatures _creature;
    public Vector3 playerPos;
    public int creatureId;
    public float range;
    public LayerMask creatureEnemy;
    private bool caught;

    public string Destination()
    {
        if(dest == MyDestination.Party)
        {
            return "Party";
        }
        else if(dest == MyDestination.Inventory)
        {
            return "Inventory";
        }
        else
        {
            return "";
        }
    }
    public void CatchCreature()
    {
        Collider2D[] creaturesInRange = Physics2D.OverlapCircleAll(transform.position, range, creatureEnemy); //Collider box checker for catching
        Debug.Log("Got to CatchCreature() Method");
        caught = false;
        creatureIds.Clear();
        foreach(Collider2D creatures in creaturesInRange)
        {
            Creatures creature = creaturesInRange[0].GetComponent<Creatures>();
            if(creature.id == 1)
            {
                dest = MyDestination.Party;
            }
            else if(creature.id == 2)
            {
                dest = MyDestination.Inventory;
            }
            // creatureIds.Add(creature.id);
            creatureId = creature.id;
            caughtMonster.Invoke();
            caught = true;

            Destroy(creaturesInRange[0].gameObject);

            // do something good
            Debug.Log("Got to inside the foreach loop");
            creatureSpawner.creatureList.Remove(creaturesInRange[0].gameObject);

            // CreatureInfo info = creatures.GetComponent<CreatureInfo>();
                
                // if(something)
                // {
                //     Debug.Log("Got to inside the If Statement");
                //     DropItems(new Item(info.droppedItemsID), info.positionOfPlant, info.amountToDrop);
                //     info.DestroyPlant();
                // }
        }
    }

    public int ReturnCreatureIds()
    {
        return creatureId;
    }
}