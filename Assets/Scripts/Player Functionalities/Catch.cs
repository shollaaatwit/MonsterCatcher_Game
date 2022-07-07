using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour, IFunctionInteract
{

    /// <summary> Class that extends from IFunctionInteract interface and implements the UseTool method for the catch function. Can open potential for different catching skills or tools </summary>
    
    public void UseTool()
    {

        CatchCreature();

    }
    public Vector3 playerPos;
    public float range;
    public LayerMask creatureEnemy;

    public void CatchCreature()
    {
        Collider2D[] creaturesInRange = Physics2D.OverlapCircleAll(transform.position, range, creatureEnemy); //Collider box checker for catching
        Debug.Log("Got to CatchCreature() Method");
        foreach(Collider2D creatures in creaturesInRange)
        {

            Destroy(creatures.gameObject); //test
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
}