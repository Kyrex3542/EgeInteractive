using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleTarget : MonoBehaviour
{
    private GameObject targetObstacle;
    public static ObstacleTarget instance { get; private set; }
    private void Start()
    {
        instance = this;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit2D.collider != null && hit2D.transform.CompareTag("Obstacle"))
            {
                if (hit2D.transform.gameObject != targetObstacle)
                {
                    Debug.Log("1");
                    targetObstacle = hit2D.transform.gameObject;
                }
                else
                {
                    Debug.Log("2");
                    targetObstacle = null;
                }
            }
        }
    }
    public GameObject GetTargetObstacle()
    {
        
        return targetObstacle;
    }
    public float GetDistanceToObstacle(Transform towerPos)
    {
        float distance = Vector2.Distance(towerPos.position, transform.position);
        return distance;
    }
}
