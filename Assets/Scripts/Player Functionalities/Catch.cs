using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class MyCaughtEvent : UnityEvent<int>
{


}
public class Catch : MonoBehaviour, IFunctionInteract
{

    /// <summary> Class that extends from IFunctionInteract interface and implements the UseTool method for the catch function. Can open potential for different catching skills or tools </summary>
    
    public void UseTool()
    {

        CatchCreature();

    }
    public int[] GetIDs()
    {

        return ReturnCreatureIds();

    }
    public bool IsCaught()
    {
        return caught;
    }
    public UnityEvent caughtMonster;
    public List<int> creatureIds = new List<int>();
    public Vector3 playerPos;
    public int creatureId;
    public float range;
    public LayerMask creatureEnemy;
    private bool caught;

    public void CatchCreature()
    {
        Collider2D[] creaturesInRange = Physics2D.OverlapCircleAll(transform.position, range, creatureEnemy); //Collider box checker for catching
        Debug.Log("Got to CatchCreature() Method");
        caught = false;
        creatureIds.Clear();
        foreach(Collider2D creatures in creaturesInRange)
        {
            Creatures creature = creatures.GetComponent<Creatures>();
            
            creatureIds.Add(creature.id);
            caughtMonster.Invoke();
            caught = true;

            Destroy(creatures.gameObject);

            // do something good
            Debug.Log("Got to inside the foreach loop");

            // CreatureInfo info = creatures.GetComponent<CreatureInfo>();
                
                // if(something)
                // {
                //     Debug.Log("Got to inside the If Statement");
                //     DropItems(new Item(info.droppedItemsID), info.positionOfPlant, info.amountToDrop);
                //     info.DestroyPlant();
                // }
        }
    }

    public int[] ReturnCreatureIds()
    {
        return creatureIds.ToArray();
    }
}