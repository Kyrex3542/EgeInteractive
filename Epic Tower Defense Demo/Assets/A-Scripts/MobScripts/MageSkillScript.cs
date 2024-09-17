using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MageSkillScript : MonoBehaviour
{
    [SerializeField] private float FollowerRate;
    [SerializeField] private float FollowerSpawnTimeRate;
    [SerializeField] private float AdditionalSpawnTimeRate = 1f;
    [SerializeField] public GameObject Follower;

    private Transform[] paths;
    private int PathCounter;
    private int FollowerCounter = 0;
    private float SpawnTimeHolder;
    private float AdditionalSpawnTimeHolder;

    private PathFinder PathLocationsGiver;
    private void Start()
    {
        SpawnTimeHolder = FollowerSpawnTimeRate;
        AdditionalSpawnTimeHolder = AdditionalSpawnTimeRate;
        PathLocationsGiver = gameObject.GetComponent<PathFinder>();
        paths = PathLocationsGiver.path;
    }
    void Update()
    {
        AdditionalSpawnTimeRate -= Time.deltaTime;
        if (AdditionalSpawnTimeRate <= 0)
        {
            DelayerOfFollowers();
        }
    }

    private void DelayerOfFollowers()
    {
        FollowerSpawnTimeRate -= Time.deltaTime;
        if (FollowerSpawnTimeRate <= 0 && FollowerCounter < FollowerRate)
        {
            Spawner(Follower);
            FollowerSpawnTimeRate = SpawnTimeHolder;
            FollowerCounter++;
        }
        else if (FollowerCounter >= FollowerRate)
        {
            AdditionalSpawnTimeRate = FollowerSpawnTimeRate = AdditionalSpawnTimeHolder;
            FollowerCounter = 0;
        }
    }

    private void Spawner(GameObject EnemyPrefab)
    {
        PathCounter = PathLocationsGiver.pathIndex;
        GameObject gameObject = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        PathFinder pathFinder = gameObject.GetComponent<PathFinder>();
        if (paths.Length > 0)
        {
            pathFinder.path = new Transform[paths.Length - PathCounter];
            for (int j = 0; j < paths.Length - PathCounter; j++)
            {
                pathFinder.path[j] = paths[j + PathCounter];
            }
            pathFinder.target = paths[PathCounter];
        }
    }
}
