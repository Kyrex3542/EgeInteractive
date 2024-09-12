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
    public bool canTurnToEnemy = true;
    private ObstacleTarget obstacleTarget;


    private void Start()
    {
        obstacleTarget = GetComponent<ObstacleTarget>();
    }
    private void LookAt()
    {
        if (targets.Count > 0&&canTurnToEnemy||obstacleTarget.GetTargetObstacle()!=null)
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
        GameObject selectedObstacle = obstacleTarget.GetTargetObstacle();

        if (selectedObstacle != null)
        {
            Debug.Log(4);
            currentTarget = selectedObstacle;
        }
        else
        {
            Debug.Log(3);
            FindClosestEnemy();
            if (currentTarget == null || !TargetInRange()) return;
        }

        LookAt();

    }
    public bool TargetInRange()
    {
        //Colliderin alanına bakılarak menzilde olup olmadığına karar verilecek ve ona göre ağac a saldırı izni verilecek
        if(targets.Count <= 0/*||obstacleTarget.GetDistanceToObstacle(transform)<range*/)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public List<GameObject> Targets()
    {
        return targets;
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
            float remainingDistance = target.GetComponent<PathFinder>().GetRemainingDistanceToBase();
            if (remainingDistance < closestDistance)
            {
                closestDistance = remainingDistance;
                targetGameObject = target;
            }
        }
        currentTarget = targetGameObject;
    }

}
