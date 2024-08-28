using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private Transform Enemy;
    public Transform[] path;
    public Transform target;
    [SerializeField] private float moveSpeed;
     private float tempMoveSpeed;
     private float normalMoveSpeed;
    private int pathIndex = 0;
    [SerializeField] private float RotationSpeed = 15f;

    private float totalDistanceToBase;
    float timer;
    private void Start()
    {
        normalMoveSpeed = moveSpeed;
    }
    void Update()
    {

        Timer();
        if (target != null)
        {
            MoveToTarget();
        }
    }



    private void MoveToTarget()
    {
        if (Vector2.Distance(transform.position, target.position) <= 0.001f)
        {
            pathIndex++;
            target = path[pathIndex];
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            float targetAngle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            Enemy.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(Enemy.eulerAngles.z, targetAngle + 90f, RotationSpeed * Time.deltaTime)));
        }
    }
    private void Timer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            BackToNormal();
        }
    }
    public float GetRemainingDistanceToBase()
    {
        int pathCounter = pathIndex;
        totalDistanceToBase = Vector2.Distance(transform.position, path[pathCounter].position);
        while (pathCounter < path.Length - 1)
        {
            totalDistanceToBase += Vector2.Distance(path[pathCounter].position, path[pathCounter + 1].position);
            pathCounter++;
        }
        return totalDistanceToBase;
    }
    public void StunMe(float stunTime,float stopSpeed)
    {
        moveSpeed = stopSpeed;
        timer = stunTime;
    }
    private void BackToNormal()
    {
        moveSpeed = normalMoveSpeed;
    }
}
