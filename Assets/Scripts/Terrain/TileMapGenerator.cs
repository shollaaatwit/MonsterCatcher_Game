using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapGenerator : MonoBehaviour
{


    public static void TileGenerator(float[,] noiseMap, int width, int height, Tilemap terrain, TileBase grassTile, float targetHeight)
    {

		terrain.ClearAllTiles();

		for(int i = 0; i < height; i++)
        {

            for(int j = 0; j < width; j++)
            {

                if(noiseMap[i, j] <= targetHeight)
                {

                    Vector3Int pos = new Vector3Int(i, j, 0);
                    terrain.SetTile(pos, grassTile);

                }

            }

        }

    }

    public static void AssignBottomCliffTileSides(int width, int height, Tilemap cliff, Tilemap cliffBottom, Tilemap terrain,
                                                    Sprite targetSprite1, Sprite targetSprite2, Sprite targetSprite3,
                                                    Sprite targetSprite4, Sprite targetSprite5, TileBase cliffBottomTile)
    {

        cliffBottom.ClearAllTiles();

        for(int i = 0; i < height; i++)
            {

                for(int j = 0; j < width; j++)
                {

                    Vector3Int pos = new Vector3Int(i, j, 0);
                    Vector3Int belowPos = new Vector3Int(i, j - 1, 0);

                    if((cliff.GetSprite(pos) == targetSprite1 || cliff.GetSprite(pos) == targetSprite2 || cliff.GetSprite(pos) == targetSprite3
                       || cliff.GetSprite(pos) == targetSprite4 || cliff.GetSprite(pos) == targetSprite5) && terrain.GetSprite(belowPos) != null)
                    {
                        cliffBottom.SetTile(belowPos, cliffBottomTile);
                    }
                    
                }

            }

    }


    public static void AssignWaterTileSides(int width, int height, Tilemap terrain, Tilemap waterTerrain, 
                                            Sprite targetSprite1, Sprite targetSprite2, Sprite targetSprite3, Sprite targetSprite4, Sprite targetSprite5,
                                            TileBase waterTileDefault, TileBase waterTile1, TileBase waterTile2, TileBase waterTile3)
    {
    	waterTerrain.ClearAllTiles();
		for(int i = -50; i < height + 50; i++)
        {

            for(int j = -50; j < width + 50; j++)
            {

                Vector3Int pos = new Vector3Int(i, j, 0);
                Vector3Int belowPos = new Vector3Int(i, j - 1, 0);
                if(terrain.GetSprite(pos) == targetSprite1)
                {
                    waterTerrain.SetTile(belowPos, waterTile1);

                }
                else if(terrain.GetSprite(pos) == targetSprite2)
                {

                    waterTerrain.SetTile(belowPos, waterTile2);

                }
                else if(terrain.GetSprite(pos) == targetSprite3)
                {

                    waterTerrain.SetTile(belowPos, waterTile2);

                }
                else if(terrain.GetSprite(pos) == targetSprite4)
                {

                    waterTerrain.SetTile(belowPos, waterTile2);

                }
                else if(terrain.GetSprite(pos) == targetSprite5)
                {

                    waterTerrain.SetTile(belowPos, waterTile3);

                }


                if(waterTerrain.GetTile(pos) == null)
                {

                    waterTerrain.SetTile(pos, waterTileDefault);
                        
                }

            }

        }

    }

}
