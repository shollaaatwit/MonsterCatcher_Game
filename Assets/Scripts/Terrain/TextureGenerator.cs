using UnityEngine;
using System.Collections;

public static class TextureGenerator 
{

	public static Texture2D TextureColorMap(Color[] colorMap, int width, int height) 
	{
		//Applies texture of same width and height of heightMap
		Texture2D texture = new Texture2D(width, height);


		//applies pixels to texture and sharpens pixels with clamp to define each pixel
		texture.filterMode = FilterMode.Point;
		texture.wrapMode = TextureWrapMode.Clamp;
		texture.SetPixels (colorMap);
		texture.Apply (); // finalizes
		
		return texture;

	}


	public static Texture2D TextureHeightMap(float[,] heightMap) 
	{
		//grabs lengths of column and row of 2D array 
		int width = heightMap.GetLength(0);
		int height = heightMap.GetLength(1);
		//array of colormap with length of area of 2D array
		Color[] colorMap = new Color[width * height];

		//traverse 2D array and slot in grayscale value based on heightMap float value
		for (int y = 0; y < height; y++) 
		{

			for (int x = 0; x < width; x++) 
			{

				colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);

			}

		}

		return TextureColorMap(colorMap, width, height);

	}

}