using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform targetPoint;
    [SerializeField] private GameObject[] EnemyPrefabArray;
    [SerializeField] private Transform[] paths;
    [SerializeField] private MapLoader mapLoader;
    private GameObject pathsParent;
    [SerializeField] float spawnTimerMax;
    private float spawnTimer;
    private void Start()
    {
        spawnTimer = spawnTimerMax;
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
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            int randomIndex = Random.Range(0, EnemyPrefabArray.Length);
            GameObject gameObject = Instantiate(EnemyPrefabArray[randomIndex], spawnPoint.position, Quaternion.identity);
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
            spawnTimer = spawnTimerMax;
        }
    }
}
