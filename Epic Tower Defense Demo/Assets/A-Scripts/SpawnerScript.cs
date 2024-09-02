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
    private GameObject pathsParent;
    private void Start()
    {
        pathsParent = mapLoader.GetPathsParent();
        paths = new Transform[pathsParent.transform.childCount];
        for (int i = 0; i < pathsParent.transform.childCount; i++)
        {
            paths[i] = pathsParent.transform.GetChild(i);
        }
        //spawnPoint = mapLoader.spawnPoint;
        targetPoint = mapLoader.targetPoint;
    }

    public int Spawner(GameObject EnemyPrefab)
    {
        int NumOfSpawnLoc = spawnPoint.Length;

        for (int i = 0; i < NumOfSpawnLoc;i++)
        {
            GameObject gameObject = Instantiate(EnemyPrefab, spawnPoint[i].position, Quaternion.identity);
            PathFinder pathFinder = gameObject.GetComponent<PathFinder>();
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
