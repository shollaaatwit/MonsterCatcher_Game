using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControllerScript : Singleton<TestControllerScript>
{
    public static TestControllerScript Instance;

    private SpriteRenderer spriteRenderer;
    private Inventory inventory;


    private int i = 0;

    [SerializeField] InventoryUI uiInventory;
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        inventory = new Inventory(UseItem);
        uiInventory.SetInventory(inventory);

        ItemWorld.SpawnItemWorld(new Vector3(-2, -1), new Item(1) {amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(2, -2), new Item(0) {amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(1, -1), new Item(1) {amount = 1});
    }

    void Update()
    {
    }


    private void UseItem(Item item)
    {
    }

    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();

        if(itemWorld != null && inventory.IsNotFull() && i == 0)
        {
            //Touching Item
            inventory.AddItem(itemWorld.GetItem());
            i++;
            itemWorld.DestroySelf();
            i = 0;

        }
        if(!inventory.IsNotFull())
        {
            Debug.Log("Inventory is full!");
        }
    }
}
