using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PerlinNoise : MonoBehaviour
{

    public float cSeed;
    public static PerlinNoise Instance;
    

    //method for calculating specific Perlin noise shapes with specific inputs creating organic figures
    //octaves, persistance, perplexity, scale, height, width, and offset(randomness) to achieve a generated seed.
    //make sure scale is never set to 0; must always be scale >= 0.0001
	public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float seed, float scale, int octaves, float persistance, float perplexity, Vector2 offset) 
    {

		float[,] noiseMap = new float[mapWidth,mapHeight];
        seed = Random.Range(-100.0f, 100.0f);

		float maxNoiseHeight = float.MinValue;
		float minNoiseHeight = float.MaxValue;
		float halfWidth = mapWidth / 2f;
		float halfHeight = mapHeight / 2f;


        Vector2[] octaveOffsets = new Vector2[octaves];



        //creating offsets and layers with octaves depending on how many are set
		for(int i = 0; i < octaves; i++) 
        {

			float offsetX = seed;
			float offsetY = seed;
			octaveOffsets[i] = new Vector2(offsetX, offsetY);

		}

		for(int y = 0; y < mapHeight; y++) 
        {
            
			for(int x = 0; x < mapWidth; x++) 
            {
		
				float amplitude = 1;
				float frequency = 1;
				float noiseHeight = 0;


				for(int i = 0; i < octaves; i++) 
                {
                    //values to hold calculations to make perlin calculation look cleaner
					float holderX = (x-halfWidth) / scale * frequency + octaveOffsets[i].x;
					float holderY = (y-halfHeight) / scale * frequency + octaveOffsets[i].y;


					float perlinV = Mathf.PerlinNoise(holderX, holderY) * 2 - 1;
                    float holderZ = perlinV * amplitude;

					noiseHeight += holderZ;
					amplitude *= persistance;
					frequency *= perplexity;

				}

				if (noiseHeight > maxNoiseHeight) 
                {

					maxNoiseHeight = noiseHeight;
                    
				} 
                else if (noiseHeight < minNoiseHeight) 
                {

					minNoiseHeight = noiseHeight;

				}

				noiseMap[x, y] = noiseHeight;

			}

		}

		for(int y = 0; y < mapHeight; y++) 
        {

			for(int x = 0; x < mapWidth; x++) 
            {
                
                //inverselerp finds a value that lies between two points, in this case, minimum height and maximum height.
				noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);

			}

		}

		return noiseMap;

	} // end of GenerateNoiseMap()


    //Make method that returns seed number to another class so that the user can retrieve seed info.
    //or for debugging.
    public float ReturnSeed(float seed)
    {
        
        return seed;

    }

}