using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (GenerateMap))]
public class MapGeneratorEditor : Editor
{
    //In inspector button to manually call upon MapGenerator()
    public override void OnInspectorGUI()
    {

        GenerateMap mapGen = (GenerateMap)target;

        DrawDefaultInspector();

        if(GUILayout.Button("Generate"))
        {

            mapGen.MapGenerator();

        }
        if(GUILayout.Button("TileMap Generator"))
        {

            mapGen.TileGenerate();

        }

    }
}
