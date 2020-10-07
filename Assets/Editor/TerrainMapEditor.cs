using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (TerrainMapGenerator))]
public class TerrainMapEditor : Editor {
    public override void OnInspectorGUI() {
        TerrainMapGenerator terrainMapGenerator = (TerrainMapGenerator) target;

        DrawDefaultInspector();

        if (GUILayout.Button("Generate")) {
            terrainMapGenerator.Generate();
        }

        if (GUILayout.Button("Clear")) {
            terrainMapGenerator.Clear();
        }

        GUILayout.Label("Save Level");
        EditorGUILayout.BeginHorizontal();
        string levelName = EditorGUILayout.TextField("Terrain");
        if (GUILayout.Button("Save")) {
            terrainMapGenerator.SaveTerrainData(levelName);
        }

        EditorGUILayout.EndHorizontal();
    }
}
