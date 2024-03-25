using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    public class World
    {
        private Terrain[,] _tiles;

        private Terrain _grassTerrain;
        private Terrain _hillTerrain;
        private Terrain _riverTerrain;

        public World(int width, int height, Texture grassTexture, Texture hillTexture, Texture riverTexture)
        {
            _tiles = new Terrain[height, width];
            _grassTerrain = new Terrain(1, false, grassTexture);
            _hillTerrain = new Terrain(3, false, hillTexture);
            _riverTerrain = new Terrain(2, true, riverTexture);
            
            GenerateTerrain(width, height);
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
                        _tiles[y, x] = _hillTerrain;
                    }
                    else
                    {
                        _tiles[y, x] = _grassTerrain;
                    }
                }
            }

            x = UnityEngine.Random.Range(0, width);
            for (y = 0; y < height; y++)
            {
                _tiles[y, x] = _riverTerrain;
            }
        }

        public Terrain GetTile(int x, int y)
        {
            return _tiles[y, x];
        }
    }
}
