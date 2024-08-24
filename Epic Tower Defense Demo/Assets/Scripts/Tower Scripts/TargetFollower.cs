using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private GameObject towerHead;
    [SerializeField] public GameObject currentTarget;
    private List<GameObject> targets = new List<GameObject>();
    public float towerrotationSpeed = 15f;




    private void LookAt()
    {
        if (targets.Count > 0)
        {
            float targetAngle = LookAngle();
            towerHead.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(towerHead.transform.eulerAngles.z, targetAngle -90, towerrotationSpeed * Time.deltaTime)));
        }
    }
    public float LookAngle()
    {
        float targetAngle = Mathf.Atan2(currentTarget.transform.position.y - transform.position.y, currentTarget.transform.position.x - transform.position.x) * Mathf.Rad2Deg;

        return targetAngle;
    }
    private void Update()
    {

        FindClosestEnemy();
        if (!TargetInRange()) return;
        LookAt();
    }
    public bool TargetInRange()
    {
        if(targets.Count <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
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
        GameObject targetGameObject = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject target in targets)
        {
            if (target == null) continue;
            float remainingDistance= target.GetComponent<PathFinder>().GetRemainingDistanceToBase();
            if (remainingDistance < closestDistance)
            {
                closestDistance = remainingDistance;
                targetGameObject = target;
            }
        }
        currentTarget = targetGameObject;
    }

}
