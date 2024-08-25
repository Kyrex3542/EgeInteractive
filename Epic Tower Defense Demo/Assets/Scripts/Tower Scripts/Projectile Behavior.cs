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
        if (target != null)
            MoveToTarget();
        else
            Destroy(gameObject);

    }
    private void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        float targetAngle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetAngle + -90f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthManager>(out HealthManager healthManager))
        {
            healthManager.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
