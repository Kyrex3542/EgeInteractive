using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    public Transform[] path;
    public Transform target;
    [SerializeField] private float moveSpeed;
    private int pathIndex = 0;
    [SerializeField] private float RotationSpeed = 15f;

    private int pathNumber=0;
    private float totalDistanceToBase;
    private void Start()
    {
      
    }
    void Update()
    {
        if (target != null)
        {
            MoveToTarget();
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
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            float targetAngle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, RotationSpeed * Time.deltaTime)));
        }
    }
    public float GetRemainingDistanceToBase()
    {
        if (target == null) return 100;
        totalDistanceToBase = Vector2.Distance(transform.position, target.position);
        while (pathNumber < path.Length)
        {
          totalDistanceToBase +=  Vector2.Distance(path[pathNumber].position, path[pathNumber].position);
            pathNumber++;
        }
        return totalDistanceToBase;
    }
}
