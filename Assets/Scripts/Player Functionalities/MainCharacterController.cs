using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : Singleton<MainCharacterController>
{
    ///<summary> Class for player functionalities and creatures only, for movement refer to the CharacterMovementController class instead </summary>
    public IFunctionInteract functionInteractable;
    private CreatureParty creatureParty;
    public Animator anim;
    private bool mybool;

    private Inventory inventory;
    
    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] CreatureUI creatureUI;
    void Start()
    {
        creatureParty = new CreatureParty(SummonCreature);
        functionInteractable = GetComponent<IFunctionInteract>();
        creatureUI.SetCreatureUI(creatureParty);

        inventory = new Inventory(UseItem);
        inventoryUI.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Catch", mybool);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            functionInteractable.UseTool(); //Grabs Creature Info from Game Object
            mybool = true;
            StartCoroutine(WaitTime());
            // if successful 
            if(functionInteractable.IsCaught())
            {
                switch(functionInteractable.Destination())
                {
                    case "Party":
                        creatureParty.AddCreature(new Creatures(functionInteractable.GetIDs()));
                        break;
                    case "Inventory":
                        if(inventory.IsNotFull())
                        {
                            inventory.AddItem(new Item(3));
                        }
                        break;
                }

                Debug.Log(functionInteractable.Destination());
            }
        }
    }

    private void UseItem(Item item)
    {

    }
    public IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.5f);
        mybool = false;
    }
    private void SummonCreature(Creatures creature)
    {
    }

}
