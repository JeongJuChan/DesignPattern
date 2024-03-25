using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    public class EnumWorld
    {
        private EnumTerrain[,] _tiles;

        public EnumWorld(int width, int height)
        {
            _tiles = new EnumTerrain[height, width];
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
                        _tiles[y, x] = EnumTerrain.TERRAIN_HILL;
                    }
                    else
                    {
                        _tiles[y, x] = EnumTerrain.TERRAIN_GRASS;
                    }
                }
            }

            x = UnityEngine.Random.Range(0, width);
            for (y = 0; y < height; y++)
            {
                _tiles[y, x] = EnumTerrain.TERRAIN_RIVER;
            }
        }

        public int GetMovementCost(int x, int y)
        {
            switch (_tiles[y, x])
            {
                case EnumTerrain.TERRAIN_GRASS:
                    return 1;
                case EnumTerrain.TERRAIN_HILL:
                    return 3;
                case EnumTerrain.TERRAIN_RIVER:
                    return 2;
            }

            return 0;
        }

        public bool IsWater(int x, int y)
        {
            switch (_tiles[y, x])
            {
                case EnumTerrain.TERRAIN_GRASS:
                    return false;
                case EnumTerrain.TERRAIN_HILL:
                    return false;
                case EnumTerrain.TERRAIN_RIVER:
                    return true;
            }

            return false;
        }
    }
}
