using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;


    public Image selector;
    public GameObject[] inventoryHotBars;

    private Button button;
    private int currentIndex;


    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        currentIndex = 0;
    }


    private void Update()
    {
        Debug.Log(currentIndex);
        if(Input.mouseScrollDelta.y > 0)
        {
            if(currentIndex < 1)
            {
                currentIndex = 11;
                // inventory.GetItemCount()-1;
            }
            else
            {
                currentIndex--;
            }
        }
        if(Input.mouseScrollDelta.y < 0)
        {
            if(currentIndex > 10)
            {
             // inventory.GetItemCount()-1)               
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
        }
        selector.transform.position = inventoryHotBars[currentIndex].transform.position;

    }

    public int ReturnSelectorIndex()
    {
        return currentIndex;
    }


    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
        Debug.Log(inventory.GetItemCount());
    }

    public void Selector()
    {
        Debug.Log(currentIndex);
        try
        {
            // Debug.Log(inventory.ReturnItem(currentIndex).itemType.ToString());
            Item hold = inventory.ReturnItem(currentIndex);
            inventory.UseItem(hold);
        }
        catch(ArgumentOutOfRangeException ex)
        {
            Debug.Log("There is no item in that slot!");
        }
    }



    private void RefreshInventoryItems()
    {
        foreach(Transform child in itemSlotContainer)
        {
            if(child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        int x = 0; // holds index of item list
        int y = 0;
        float itemSlotCellSize = 227f;


        //add system to match transform potion of inventory hotbars
        //right now its hardcoded positions
        int i = 0;
        foreach(Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);


            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y*itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            button = image.GetComponent<Button>();
            button.onClick.AddListener(delegate{inventory.UseItem(item);});
            image.sprite = item.GetSprite(item.id);



            x++;
            if(x >= 4)
            {
                x = 0;
                y++;
            }
        }
    }


}