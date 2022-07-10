using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreatureParty : Singleton<CreatureParty>
{

    public List<Creatures> creatures;
    public event EventHandler OnCreaturesListChanged;
    private Action<Creatures> useCreatureAction;

    public CreatureParty(Action<Creatures> useCreatureAction)
    {
        this.useCreatureAction = useCreatureAction;
        creatures = new List<Creatures>();
        foreach(Creatures creature in creatures)
        {
            Debug.Log(creature.id);
        }
    }

    public void AddCreature(Creatures creature)
    {
        creatures.Add(creature);
        OnCreaturesListChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log(creatures.Count);
    }

    public void RemoveItem(Creatures creature)
    {
        Creatures creatureInParty = null;
        foreach(Creatures partyCreatures in creatures)
        {
            if(partyCreatures.id == creature.id)
            {
                creatureInParty = partyCreatures;
            }
        }
        if (creatureInParty != null)
        {
            creatures.Remove(creatureInParty);
        }
        else
        {
            creatures.Remove(creature);
        }
        OnCreaturesListChanged?.Invoke(this, EventArgs.Empty); 
    }

    public void SummonCreature(Creatures creature)
    {
       useCreatureAction(creature); 
    }

    public Creatures ReturnCreature(int index)
    {
        return creatures[index];
    }

    public List<Creatures> GetCreatureList()
    {
        return creatures;
    }

    public int GetCreaturesCount()
    {
        return creatures.Count;
    }

    public bool IsFull()
    {
        if(creatures.Count > 6)
        {
            return false;
        }
        return true;
    }
}
