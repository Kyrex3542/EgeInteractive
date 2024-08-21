using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject towerHead;
    [SerializeField] private GameObject towerBase;
    [SerializeField] private GameObject currentTarget;
    private List<GameObject> targets = new List<GameObject>();
    public float towerrotationSpeed = 15f;

    private float lastKnownClosestEnemy=Mathf.Infinity;
    private float closestEnemy;
    private void LookAt()
    {
        if (targets.Count > 0)
        {
            FindClosestEnemy();

            float targetAngle = Mathf.Atan2(currentTarget.transform.position.y - transform.position.y, currentTarget.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            towerHead.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(towerHead.transform.eulerAngles.z, targetAngle -90, towerrotationSpeed * Time.deltaTime)));
        }
    }
    private void Update()
    {
        LookAt();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            targets.Add(collision.gameObject);//Birden fazla obje menzile girdiðinde onlarý listeye atýyor
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
            targets.Remove(other.gameObject);

    }
    private void FindClosestEnemy()
    {
        if (targets.Count <= 0) return;
        lastKnownClosestEnemy = Mathf.Infinity;
        foreach (GameObject target in targets)
        {
            PathFinder pathFinder = target.GetComponent<PathFinder>();
            closestEnemy= pathFinder.GetRemainingDistanceToBase();
            if (closestEnemy < lastKnownClosestEnemy)
            {
                currentTarget= target;
                lastKnownClosestEnemy = closestEnemy;
            }
        }
    }
}
