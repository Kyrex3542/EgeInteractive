using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject towerHead;
    [SerializeField] private GameObject towerBase;
    [SerializeField] private GameObject target;


    private void LookAt()
    {
        if (target != null) return;
        //float angle=MathF.Atan2(targetPos.y-transform.position.y, targetPos.x-transform.position.x)*Mathf.Rad2Deg;   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        target=collision.gameObject;


    }
}
