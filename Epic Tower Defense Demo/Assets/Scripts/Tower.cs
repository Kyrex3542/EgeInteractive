using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject towerHead;
    [SerializeField] private GameObject towerBase;
    [SerializeField] private GameObject target;

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
