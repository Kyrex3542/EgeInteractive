using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuldozerTowerMechanics : MonoBehaviour
{
    [SerializeField] private TargetFollower targetFollower;

    [SerializeField] private GameObject currentTarget;
    [SerializeField] private CircleCollider2D circleCollider2D;

    [Header("Weapon Properties")]
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField, Tooltip("Round Per Second")] private float fireRate;

    private float fireRateTimerMax = 5;
    private float fireRateTimer = 0;
    private void Start()
    {
        fireRateTimerMax = 1 / fireRate;
        circleCollider2D.radius = range;
    }
    private void Update()
    {
        currentTarget = targetFollower.currentTarget;
        if (currentTarget != null && targetFollower.TargetInRange())
        {
            Fire();
        }
    }

    private void Fire()
    {
        fireRateTimer -= Time.deltaTime;
        if (fireRateTimer < 0)
        {
            List<GameObject> targets = targetFollower.Targets();
            foreach (GameObject target in targets)
            {
                if (target.TryGetComponent<HealthManager>(out HealthManager healthManager))
                {
                    healthManager.TakeDamage(damage);
                }
            }
            fireRateTimer = fireRateTimerMax;
        }
    }
}
