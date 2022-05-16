using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform trans = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f) ) );
        ItemWorld itemWorld = trans.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }
    private Item item;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite(item.id);
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }


}
