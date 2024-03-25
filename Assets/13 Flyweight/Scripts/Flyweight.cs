using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    public class Flyweight : MonoBehaviour
    {
        [SerializeField] private int width = 10;
        [SerializeField] private int height = 10;
        [SerializeField] private int trialCount = 1000000;

        [SerializeField] private World world;

        void Start()
        {
            world.Init(width, height);

            int cost = world.GetTile(2, 3).GetMovementCost();
            Debug.Log(cost);

            TestPerformance(world);
        }

        private void TestPerformance(World world)
        {
            EnumWorld enumWorld = new EnumWorld(width, height);

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            GetMovementCosts(world);
            stopwatch.Stop();
            float elapsedWorldTime = stopwatch.ElapsedMilliseconds;

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
