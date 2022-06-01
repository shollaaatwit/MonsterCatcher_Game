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
	public Vector2 offset;

	public Color grassGreen = new Color(0.5320f, 1f, 0.4575f, 0f);

	public Tilemap mainTileMap;
	public TileBase grassTile;


	public float currentSeed;


	public int mapWidth;
	public int mapHeight;
	public int octaves;


	[Range(0,1)]
	public float persistance;
	public float perplexity;
	public float seed;
	public float noiseScale;

	public void MapGenerator() 
	{
		float[,] noiseMap = PerlinNoise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, perplexity, offset);
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

		mainTileMap.ClearAllTiles();

		for(int i = 0; i < mapHeight; i++)
        {

            for(int j = 0; j < mapWidth; j++)
            {

                if(colorMap[i * mapWidth + j].g == grassGreen.g)
				// if(ColorChecker.IsEqual(colorMap[i * mapWidth + j], grassGreen))
                {
					Debug.Log("hey");
                    Vector3Int pos = new Vector3Int(i, j, 0);
                    mainTileMap.SetTile(pos, grassTile);

                }

            }

        }
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