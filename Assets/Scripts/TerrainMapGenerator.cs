using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMapGenerator : MonoBehaviour {

    public GameObject forest;

    public int mapWidth;
    public int mapHeight;
    public int mapDepth;
    public float noiseScale;
    public int noiseOctaves;
    public float persistence;
    public float lacunarity;
    public int mapOffsetX;
    public int mapOffsetY;

    void Start() {
        Terrain terrain = GetComponent<Terrain>();
        ForestGenerator forestGenerator = forest.GetComponent<ForestGenerator>();

        float[,] noiseMap = Noise.GeneratePerlinNoiseMap(mapWidth, mapHeight, noiseScale, mapOffsetX, mapOffsetY, noiseOctaves, persistence, lacunarity);
        terrain.terrainData = GenerateTerrainData(terrain.terrainData, noiseMap, mapWidth, mapHeight, mapDepth);
    
        forestGenerator.Generate(terrain.terrainData);
    }

    public TerrainData GenerateTerrainData(TerrainData terrainData, float[,] noise, int width, int height, int depth) {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, noise);

        return terrainData;
    }
}
