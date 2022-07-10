using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : Singleton<MainCharacterController>
{
    ///<summary> Class for player functionalities and creatures only, for movement refer to the CharacterMovementController class instead </summary>
    public IFunctionInteract functionInteractable;
    private CreatureParty creatureParty;


    [SerializeField] CreatureUI creatureUI;
    void Start()
    {
        creatureParty = new CreatureParty(SummonCreature);
        functionInteractable = GetComponent<IFunctionInteract>();
        creatureUI.SetCreatureUI(creatureParty);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            functionInteractable.UseTool(); //Grabs Creature Info from Game Object
            // if successful 
            if(functionInteractable.IsCaught())
            {
                int[] ids = new int[functionInteractable.GetIDs().Length];
                Array.Copy(functionInteractable.GetIDs(), ids, functionInteractable.GetIDs().Length);
                for(int i = 0; i < ids.Length; i++)
                {
                    creatureParty.AddCreature(new Creatures(ids[i]));
                }
            }
        }
    }

    private void SummonCreature(Creatures creature)
    {
    }

}
