using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
    public static bool IsEqual(Color color1, Color color2)
    {  

        bool value = false;
        if(color1.r == color2.r && color1.g == color2.g && color1.b == color2.b)
        {
            value = true;
        }

        return value;

    }
}
