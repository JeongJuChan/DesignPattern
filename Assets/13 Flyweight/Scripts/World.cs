using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    [Serializable]
    public class World
    {
        private Terrain[,] _tiles;

        [SerializeField] private Terrain[] terrainTemplate;

        private Dictionary<EnumTerrain, Terrain> _terrainDict = new Dictionary<EnumTerrain, Terrain>();

        public void Init(int width, int height)
        {
            InitTerrainDict();
            _tiles = new Terrain[height, width];
            GenerateTerrain(width, height);
        }

        private void InitTerrainDict()
        {
            foreach (var terrain in terrainTemplate)
            {
                if (!_terrainDict.ContainsKey(terrain.TerrainType))
                    _terrainDict.Add(terrain.TerrainType, terrain);
            }
        }

        private void GenerateTerrain(int width, int height)
        {
            int x;
            int y;

            for (y = 0; y < height; y++)
            {
                for (x = 0; x < width; x++)
                {
                    if (UnityEngine.Random.Range(0, 11) == 0)
                    {
                        _tiles[y, x] = _terrainDict[EnumTerrain.TERRAIN_GRASS];
                    }
                    else
                    {
                        _tiles[y, x] = _terrainDict[EnumTerrain.TERRAIN_HILL];
                    }
                }
            }

            x = UnityEngine.Random.Range(0, width);
            for (y = 0; y < height; y++)
            {
                _tiles[y, x] = _terrainDict[EnumTerrain.TERRAIN_RIVER];
            }
        }

        public Terrain GetTile(int x, int y)
        {
            return _tiles[y, x];
        }
    }
}
