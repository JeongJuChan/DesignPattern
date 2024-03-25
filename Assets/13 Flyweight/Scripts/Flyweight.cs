using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    public class Flyweight : MonoBehaviour
    {
        [SerializeField] private int width = 10;
        [SerializeField] private int height = 10;
        [SerializeField] private int trialCount = 100;

        [SerializeField] private Texture grassTexutre;
        [SerializeField] private Texture hillTexutre;
        [SerializeField] private Texture riverTexutre;

        void Start()
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

            World world = new World(width, height, grassTexutre, hillTexutre, riverTexutre);
            
            stopwatch.Start();
            GetMovementCosts(world);
            stopwatch.Stop();
            float elapsedWorldTime = stopwatch.ElapsedMilliseconds;
            
            EnumWorld enumWorld = new EnumWorld(width, height);
            stopwatch.Start();
            GetEnumMovementCosts(enumWorld);
            stopwatch.Stop();
            float elapsedEnumWorldTime = stopwatch.ElapsedMilliseconds;

            Debug.Log($"worldTime : {elapsedWorldTime}, enumWorldTime : {elapsedEnumWorldTime}");
        }

        private void GetMovementCosts(World world)
        {
            for (int i = 0; i < trialCount; i++)
            {
                int x = UnityEngine.Random.Range(0, width);
                int y = UnityEngine.Random.Range(0, height);
                world.GetTile(y, x).GetMovementCost();
            }
        }

        private void GetEnumMovementCosts(EnumWorld enumWorld)
        {
            for (int i = 0; i < trialCount; i++)
            {
                int x = UnityEngine.Random.Range(0, width);
                int y = UnityEngine.Random.Range(0, height);
                enumWorld.GetMovementCost(x, y);
            }
        }
    }
}
