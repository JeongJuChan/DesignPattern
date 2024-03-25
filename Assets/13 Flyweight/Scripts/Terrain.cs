using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    [CreateAssetMenu(menuName = "SO/Terrain", fileName = "Terrain")]
    public class Terrain : ScriptableObject
    {
        [field: SerializeField] public EnumTerrain TerrainType { get; private set; }
        [field: SerializeField] public int MovementCost { get; private set; }
        [field: SerializeField] public bool IsWater { get; private set; }
        [field: SerializeField] public Texture Texture { get; private set; }

        public int GetMovementCost()
        {
            return MovementCost;
        }

        public bool GetIsWater()
        {
            return IsWater;
        }

        public Texture GetTexture()
        {
            return Texture;
        }
    }
}
