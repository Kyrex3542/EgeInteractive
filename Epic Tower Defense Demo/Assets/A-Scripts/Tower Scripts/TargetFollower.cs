using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private GameObject towerHead;
    [SerializeField] public GameObject currentTarget;
    private List<GameObject> targets = new List<GameObject>();
    public float towerrotationSpeed = 15f;
    public bool canTurnToEnemy = true;
    private CircleCollider2D circleCollider;
    private GameObject selectedObstacle;
    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        ObstacleTarget.instance.OnObstacleTargetSelected += ObstacleTarget_OnObstacleTargetSelected;
    }

    private void ObstacleTarget_OnObstacleTargetSelected(object sender, System.EventArgs e)
    {
        selectedObstacle = ObstacleTarget.instance.GetTargetObstacle();
    }

    private void Update()
    {
        UpdateCurrentTarget();
        LookAtTarget();
    }

    private void UpdateCurrentTarget()
    {
        if (selectedObstacle != null && !TargetInRange())
        {
            currentTarget = selectedObstacle;
        }
        else
        {
            FindClosestEnemy();
        }

        /*if (currentTarget == null && !TargetInRange())
        {
            currentTarget = null;
        }*/
    }

    private void LookAtTarget()
    {
        if (currentTarget == null || (!canTurnToEnemy && ObstacleTarget.instance.GetTargetObstacle() == null))
        {
            return;
        }

        float targetAngle = CalculateAngleToTarget();
        towerHead.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(towerHead.transform.eulerAngles.z,targetAngle - 90,towerrotationSpeed * Time.deltaTime)));
    }

    private float CalculateAngleToTarget()
    {
        Vector2 direction = (currentTarget.transform.position - transform.position).normalized;
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    public bool TargetInRange()
    {
        if (currentTarget == null || ObstacleTarget.instance.GetTargetObstacle() == null)
        {
            return false;
        }

        float distanceToTarget = ObstacleTarget.instance.GetDistanceToObstacle(currentTarget.transform);
        if (!(distanceToTarget < circleCollider.radius))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void FindClosestEnemy()
    {
        if (targets.Count == 0) return;

        GameObject closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            if (target == null) continue;

            float remainingDistance = target.GetComponent<PathFinder>().GetRemainingDistanceToBase();
            if (remainingDistance < closestDistance)
            {
                closestDistance = remainingDistance;
                closestTarget = target;
            }
        }

        currentTarget = closestTarget;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            targets.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            targets.Remove(other.gameObject);
        }
    }
    public List<GameObject> Targets()
    {
        return targets;
    }
}
