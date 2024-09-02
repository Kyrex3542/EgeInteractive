using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private Transform Enemy;
    public Transform[] path;
    public Transform target;
    [SerializeField] private float moveSpeed;
    private float normalMoveSpeed;
    private float modifiedMoveSpeed;
    private float timerMax;
    private float timer;
    private int pathIndex = 0;
    private float RotationSpeed = 15f;

    private float totalDistanceToBase;
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

    public void StunMe(float stunTime, float stopSpeed)
    {
        moveSpeed = stopSpeed;
        timer = stunTime;
    }

    public void SlowMe(float slowTime, float slowPercentage)
    {
        moveSpeed = moveSpeed * slowPercentage;
        timer = slowTime;
    }

    private void BackToNormal()
    {
        moveSpeed = normalMoveSpeed;
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
}
