using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform spawnPoint;
    public Transform targetPoint;
    [SerializeField] private Transform[] paths;
    [SerializeField] private MapLoader mapLoader;
    private GameObject pathsParent;
    private void Start()
    {
        pathsParent = mapLoader.GetPathsParent();
        paths=new Transform[pathsParent.transform.childCount];
        for (int i = 0; i < pathsParent.transform.childCount; i++)
        {
            paths[i]=pathsParent.transform.GetChild(i);
        }
        spawnPoint = mapLoader.spawnPoint;
        targetPoint = mapLoader.targetPoint;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject gameObject = Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity);
            PathFinder pathFinder = gameObject.GetComponent<PathFinder>();
            if (paths.Length > 0)
            {
                pathFinder.path=new Transform[paths.Length];
                for (int i = 0; i < paths.Length ; i++)
                {
                    pathFinder.path[i] = paths[i];
                }
                pathFinder.target = paths[0];
            }
        }
    }
}
