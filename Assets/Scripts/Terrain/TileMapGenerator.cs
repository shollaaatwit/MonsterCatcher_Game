using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapGenerator : MonoBehaviour
{

    public static Color grassGreen = new Color(0.5320f, 1f, 0.4575f, 0f);

    public static Tilemap TileGenerator(Color[] colorMap, int width, int height, Tilemap terrain, Tile grassTile)
    {

        for(int i = 0; i < height; i++)
        {

            for(int j = 0; j < width; j++)
            {

                if(colorMap[i * width + j] == grassGreen)
                {

                    Vector3Int pos = new Vector3Int(i, j, 0);
                    terrain.SetTile(pos, grassTile);

                }

            }

        }

        return terrain;

    }

}
