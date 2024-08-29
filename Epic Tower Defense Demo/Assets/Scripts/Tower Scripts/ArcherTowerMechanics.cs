using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTowerMechanics : MonoBehaviour
{
    [SerializeField]private TargetFollower targetFollower;

    [SerializeField] private GameObject currentTarget;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectilePushForce;
    [SerializeField] private CircleCollider2D circleCollider2D;

    [Header("Weapon Properties")]
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField, Tooltip("Round Per Second")] private float fireRate;

    private float fireRateTimerMax=5;
    private float fireRateTimer=0;
    private void Start()
    {
        fireRateTimerMax = 1 / fireRate;
        circleCollider2D.radius = range;
    }
    private void Update()
    {
        fireRateTimer -=Time.deltaTime;
        currentTarget = targetFollower.currentTarget;
        if (currentTarget != null&&targetFollower.TargetInRange())
        {
            Fire(); 
        }
    }

    private void Fire()
    {
        if (fireRateTimer < 0)
        {
            GameObject createdProjectile = Instantiate(projectile, firePoint.position, firePoint.transform.rotation);
            ProjectileBehavior projectileBehavior = createdProjectile.GetComponent<ProjectileBehavior>();
            projectileBehavior.moveSpeed = projectilePushForce;
            projectileBehavior.damage = damage;
            projectileBehavior.target = currentTarget.transform;
            fireRateTimer = fireRateTimerMax;
        }
    }
}
