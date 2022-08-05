using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateMap : MonoBehaviour
{
	
	private float[,] noiseMap;
	public Vector2 offset;

	public Transform player;
	public Tilemap mainTileMap;
	public Tilemap waterTerrain;
	public Tilemap higherTerrain;
	public Tilemap higherBottomTerrain;
	public TileBase grassTile;
	public TileBase[] waterTiles;
	public TileBase cliffBottomTile;

	public Sprite[] waterTargetSprites;
	public Sprite[] cliffTargetSprites;


	public float currentSeed;


	public int mapWidth;
	public int mapHeight;
	public int octaves;


	[Range(0,1)]
	public float persistance;
	public float perplexity;
	public float seed;
	public float noiseScale;

	void Start()
	{
		MapGenerator();
		TileGenerate();
		CheckPlayerSpawn();
	}

	public void MapGenerator() 
	{
		noiseMap = PerlinNoise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, perplexity, offset);
		for (int y = 0; y < mapHeight; y++) 
		{
			for (int x = 0; x < mapWidth; x++) 
			{
				float currentHeight = noiseMap[x, y];
			}
		}

	}

	public void TileGenerate()
	{

		TileMapGenerator.TileGenerator(noiseMap, mapWidth, mapHeight, mainTileMap, grassTile, 0.7f);
		TileMapGenerator.AssignWaterTileSides(mapWidth, mapHeight, mainTileMap, waterTerrain,
												waterTargetSprites[0], waterTargetSprites[1], waterTargetSprites[2], waterTargetSprites[3], waterTargetSprites[4],
												waterTiles[0], waterTiles[1], waterTiles[2], waterTiles[3]);

		TileMapGenerator.TileGenerator(noiseMap, mapWidth, mapHeight, higherTerrain, grassTile, 0.25f);

		TileMapGenerator.AssignBottomCliffTileSides(mapWidth, mapHeight, higherTerrain, higherBottomTerrain, mainTileMap,
													cliffTargetSprites[0], cliffTargetSprites[1], cliffTargetSprites[2], cliffTargetSprites[3], cliffTargetSprites[4],
													cliffBottomTile);
	}



	public void CheckPlayerSpawn()
	{

		Vector3Int tilePos = mainTileMap.WorldToCell(player.position);
		while(mainTileMap.GetTile(tilePos) != grassTile)
		{
			tilePos = new Vector3Int((int)player.position.x,(int) player.position.y, 0);
		}

		player.position = mainTileMap.GetCellCenterWorld(new Vector3Int(tilePos.x+1, tilePos.y+1, 0));

	}

}