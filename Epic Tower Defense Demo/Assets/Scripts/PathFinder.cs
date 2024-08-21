using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    public Transform[] path;
    private Transform target;
    private int pathIndex = 0;
    private float RotationSpeed = 5f;
    private void Start()
    {
        PathFounder();
        target = path[0];
    }
    void Update()
    {
        MoveToTarget();
    }

    private void PathFounder()
    {
        GameObject[] pathObjects = GameObject.FindGameObjectsWithTag("Path");
        path = new Transform[pathObjects.Length];
        for (int i = 0; i < pathObjects.Length; i++)
        {
            path[i] = pathObjects[pathObjects.Length - i - 1].transform;
        }
    }

    private void MoveToTarget()
    {
        if (Vector2.Distance(transform.position, target.position) <= 0.01f)
        {
            pathIndex++;
            target = path[pathIndex];
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, 4f * Time.deltaTime);
            float targetAngle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, 15f * Time.deltaTime)));
        }
    }
}
