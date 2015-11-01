using UnityEditor;
using UnityEngine;
using System.Collections;


[CustomEditor(typeof(TileMap))]
public class TileMapInspector : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Generate"))
        {
            TileMap tileMap = (TileMap)target;
            tileMap.BuildMap();

        }
        if (GUILayout.Button("Destroy"))
        {
            TileMap tileMap = (TileMap)target;
            tileMap.DestroyMap();

        }

    }
}
