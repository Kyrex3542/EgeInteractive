using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleTarget : MonoBehaviour
{
    private GameObject targetObstacle;
    [SerializeField] private GameObject obstaclePointer;

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
                    targetObstacle = hit2D.transform.gameObject;

                    Vector2 pos = targetObstacle.transform.position;
                    pos.y += 1;
                    obstaclePointer.SetActive(true);
                    obstaclePointer.transform.position = pos;

                }
                else
                {
                    obstaclePointer.SetActive(false);
                    targetObstacle = null;
                }
            }
        }
    }
    public GameObject GetTargetObstacle()
    {
        
        return targetObstacle;
    }
    public float GetDistanceToObstacle(Transform currentTarget)
    {
        float distance = Vector2.Distance(transform.position, currentTarget.position);
        return distance;
    }
}
