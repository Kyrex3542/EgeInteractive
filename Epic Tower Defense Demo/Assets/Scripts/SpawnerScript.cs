using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject EnemyPrefab;
    [SerializeField] private Transform[] paths;
    [SerializeField] private MapLoader mapLoader;
    private GameObject pathsParent;
    private void Start()
    {
        pathsParent = mapLoader.GetPathsParent();
        for (int i = 0; i < pathsParent.transform.childCount; i++)
        {
            paths[i]=pathsParent.transform.GetChild(i);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject gameObject = Instantiate(EnemyPrefab, transform.position, transform.rotation);
            PathFinder pathFinder = gameObject.GetComponent<PathFinder>();
            if (paths.Length > 0)
            {
                pathFinder.path=new Transform[paths.Length] ;
                for (int i = 0; i < paths.Length ; i++)
                {
                    pathFinder.path[i] = paths[i];
                }
                pathFinder.target = paths[0];
            }
        }
    }
}
