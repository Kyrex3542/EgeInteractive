using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject EnemyPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(EnemyPrefab, transform.position, transform.rotation);
        }
    }
}
