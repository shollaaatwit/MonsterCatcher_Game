using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreatureSpawner : Singleton<CreatureSpawner>
{

    public GameObject player;

    public GameObject[] creature;

    public TileBase grassBlock;

    public Tilemap grassTerrain;

    public Transform[] spawnPoints;

    public List<GameObject> creatureList = new List<GameObject>();

    public bool spawnTime;

    private int posX;
    private int tick = 1;

    private double spawnChance;

    void Start()
    {

        InvokeRepeating("SpawnMob", 2.0f, 2.0f);
        InvokeRepeating("DespawnFarMobs", 2.0f, 2.0f);
    }

    public void SpawnMob()
    {
        Debug.Log("spawn chance");
        posX = Random.Range(1, spawnPoints.Length);
        spawnChance = (double)Random.Range(1, 100);
        int index = Random.Range(0,2);
        if(grassTerrain.GetTile(grassTerrain.WorldToCell(spawnPoints[posX].position)) == grassBlock && spawnChance > 30.99999f && creatureList.Count < 7)
        {

            creatureList.Add(Instantiate(creature[index], spawnPoints[posX].position, Quaternion.identity, transform));

        }
    }

    public void DontSpawnMob()
    {
        spawnTime = false;
    }

    public void DespawnFarMobs()
    {
        foreach(GameObject gObjects in creatureList)
        {
            if(Vector2.Distance(gObjects.transform.position, player.transform.position) > 16)
            {
                Destroy(gObjects);
                creatureList.Remove(gObjects);
            }
        }

    }
}
