using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureUI : MonoBehaviour
{

    private CreatureParty creatures;

    private Transform creaturePartyHolder;
    private Transform creatureSlot;

    private void Awake()
    {
        creaturePartyHolder = transform.Find("Creature Party");
        creatureSlot = creaturePartyHolder.Find("Slot");
    }

    public void SetCreatureUI(CreatureParty creatures)
    {
        this.creatures = creatures;
        creatures.OnCreaturesListChanged += CreatureParty_OnCreaturesListChanged;
        RefreshCreatureParty();
    }

    private void CreatureParty_OnCreaturesListChanged(object sender, System.EventArgs e)
    {
        RefreshCreatureParty();
    }

    private void RefreshCreatureParty()
    {
        foreach(Transform child in creaturePartyHolder)
        {
            if(child == creatureSlot) continue;
            Destroy(child.gameObject);
        }
        int x = 0; // holds index of item list
        float itemSlotCellSize = 75f;
        int i = 0;
        foreach(Creatures creature in creatures.GetCreatureList())
        {
            RectTransform creatureSlotRectTransform = Instantiate(creatureSlot, creaturePartyHolder).GetComponent<RectTransform>();
            creatureSlotRectTransform.gameObject.SetActive(true);


            creatureSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, 0);
            Image image = creatureSlotRectTransform.Find("Image").GetComponent<Image>();

            image.sprite = creature.GetSprite(creature.id);



            x++;
        }
    }
}
