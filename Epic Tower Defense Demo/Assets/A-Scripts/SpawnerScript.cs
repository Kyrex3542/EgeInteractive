using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Transform[] spawnPoint;
    public Transform targetPoint;
    [SerializeField] private Transform[] paths;
    [SerializeField] private MapLoader mapLoader;
    private GameObject[] pathsParent;
    private void Start()
    {
        pathsParent = mapLoader.GetPathsParent();
        spawnPoint = mapLoader.GetSpawnLocs();
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            spawnPoint[i] = mapLoader.spawnPoint[i];
        }
        targetPoint = mapLoader.targetPoint;
    }

    public int Spawner(GameObject EnemyPrefab)
    {
        int NumOfSpawnLoc = spawnPoint.Length;
        for (int i = 0; i < NumOfSpawnLoc; i++)
        {
            GameObject gameObject = Instantiate(EnemyPrefab, spawnPoint[i].position, Quaternion.identity);
            PathFinder pathFinder = gameObject.GetComponent<PathFinder>();
            paths = new Transform[pathsParent[i].transform.childCount];
            for (int j = 0; j < pathsParent[i].transform.childCount; j++)
            {
                paths[j] = pathsParent[i].transform.GetChild(j);
            }
            if (paths.Length > 0)
            {
                pathFinder.path = new Transform[paths.Length];
                for (int j = 0; j < paths.Length; j++)
                {
                    pathFinder.path[j] = paths[j];
                }
                pathFinder.target = paths[0];
            }
        }
        return NumOfSpawnLoc;
    }
}
