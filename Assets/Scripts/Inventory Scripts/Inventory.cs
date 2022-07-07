using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : Singleton<Inventory>
{
    public List<Item> items;
    public event EventHandler OnItemListChanged;
    private Action<Item> useItemAction;
    public UnityEvent ItemRemoved;
    public UnityEvent UsedItem;


    public Inventory(Action<Item> useItemAction)
    {
        this.useItemAction = useItemAction;
        items = new List<Item>();
        Debug.Log(items.Count);
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void SwapItems(Item item1, Item item2)
    {
        Item holder = item1;
        item1 = item2;
        item2 = holder;
    }


    public void RemoveItem(Item item)
    {
        Item itemInInventory = null;
        foreach(Item inventoryItem in items)
        {
            if(inventoryItem.id == item.id)
            {
                itemInInventory = inventoryItem;
            }
        }
        if (itemInInventory != null)
        {
            items.Remove(itemInInventory);
        }
        else
        {
            items.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty); 
    }

    public void UseItem(Item item)
    {
        useItemAction(item);
    }

    public Item ReturnItem(int index)
    {
        return items[index];
    }

    public List<Item> GetItemList()
    {
        return items;
    }

    public int GetItemCount()
    {
        return items.Count;
    }

    public bool IsNotFull()
    {
        if(items.Count > 12)
        {
            return false;
        }
        return true;
    }

}
