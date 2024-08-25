using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public float damage;


    private void Update()
    {
        MoveToTarget();
    }
    private void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
    }
   
}
