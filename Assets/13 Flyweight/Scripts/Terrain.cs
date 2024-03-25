using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    public class Terrain
    {
        private int _movementCost;
        private bool _isWater;
        private Texture _texture;

        public Terrain(int movementCost, bool isWater, Texture texture)
        {
            _movementCost = movementCost;
            _isWater = isWater;
            _texture = texture;
        }

        public int GetMovementCost()
        {
            return _movementCost;
        }

        public bool IsWater()
        {
            return _isWater;
        }

        public Texture GetTexture()
        {
            return _texture;
        }
    }
}
