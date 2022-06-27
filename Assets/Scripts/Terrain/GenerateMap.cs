using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateMap : MonoBehaviour
{
	
	public enum DrawMode {NoiseMap, ColorMap};
	public DrawMode drawMode;
	public TerrainType[] regions;
	private Color[] colorMap;
	private float[,] noiseMap;
	public Vector2 offset;

	public Color grassGreen = new Color(0.5320f, 1f, 0.4575f, 0f);
	public Color higherGrassGreen = new Color(0.3242112f, 0.8773585f, 0.2358935f, 0f);

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
	}

	public void MapGenerator() 
	{
		noiseMap = PerlinNoise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, perplexity, offset);
		//stores float values for each pixel created by the PerlinNoise class's GenerateNoiseMap method
		colorMap = new Color[mapWidth * mapHeight];
		//for loop for traversing 2-Dimensional Array of the noisemap and assigning height values
		for (int y = 0; y < mapHeight; y++) 
		{
			for (int x = 0; x < mapWidth; x++) 
			{
				float currentHeight = noiseMap[x, y];
				AssignColor(currentHeight, x, y, colorMap);
			}
		}
		SwapDrawMode(noiseMap, colorMap, mapWidth, mapHeight);

	}


	//method for comparing current float heights in the heightmap and applying the region's color according to it
	public void AssignColor(float cHeight, int x, int y, Color[] colorMap)
	{

		for (int i = 0; i < regions.Length; i++)
		{
			if (cHeight <= regions[i].height) 
			{
				colorMap[y * mapWidth + x] = regions[i].color;
				break;
			}
		}

	}

	public void TileGenerate()
	{

		TileMapGenerator.TileGenerator(noiseMap, mapWidth, mapHeight, mainTileMap, grassTile, grassGreen, 0.7f);
		TileMapGenerator.AssignWaterTileSides(mapWidth, mapHeight, mainTileMap, waterTerrain,
												waterTargetSprites[0], waterTargetSprites[1], waterTargetSprites[2], waterTargetSprites[3], waterTargetSprites[4],
												waterTiles[0], waterTiles[1], waterTiles[2], waterTiles[3]);

		TileMapGenerator.TileGenerator(noiseMap, mapWidth, mapHeight, higherTerrain, grassTile, higherGrassGreen, 0.25f);

		TileMapGenerator.AssignBottomCliffTileSides(mapWidth, mapHeight, higherTerrain, higherBottomTerrain, mainTileMap,
													cliffTargetSprites[0], cliffTargetSprites[1], cliffTargetSprites[2], cliffTargetSprites[3], cliffTargetSprites[4],
													cliffBottomTile);
	}

	
	//SwapDrawMode has conditionals for switching between
	//different 2DTextures in the Unity inspector between heightMap and colorMap
	//helps with comparing textures for debugging
	public void SwapDrawMode(float[,] noiseMap, Color[] colorMap, int width, int height)
	{

		MapDisplay display = FindObjectOfType<MapDisplay>();
		if (drawMode == DrawMode.NoiseMap) 
		{
			display.DrawTexture(TextureGenerator.TextureHeightMap(noiseMap));
		} 
		else if (drawMode == DrawMode.ColorMap)
		{
			display.DrawTexture(TextureGenerator.TextureColorMap(colorMap, width, height));
		}

	}

}


//custom class that can be edited from inspector for creating regions easily
[System.Serializable]
public struct TerrainType 
{

	public string name;
	public float height;
	public Color color;

}