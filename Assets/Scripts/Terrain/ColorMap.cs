using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMap : MonoBehaviour
{
    public Color testColor; 


    public Texture2D CreateColorMap(Color color, Texture2D noiseTex)
    {
        for(int i = 0; i < noiseTex.width; i++)
        {
            for(int j = 0; j < noiseTex.height; j++)
            {
                if(noiseTex.GetPixel(i, j) == testColor)
                {
                    noiseTex.SetPixel(i,j, color);
                }
            }
        }
        noiseTex.Apply();
        return noiseTex;
    }
}
