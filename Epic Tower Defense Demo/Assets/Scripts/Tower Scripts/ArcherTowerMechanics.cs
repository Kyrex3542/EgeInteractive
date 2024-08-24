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

    [Header("Weapon Properties")]
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float fireRate;

    private float fireRateTimerMax=5;
    private float fireRateTimer=0;
    private void Start()
    {
        fireRateTimerMax = 1 / fireRate;
    }
    private void Update()
    {
        currentTarget = targetFollower.currentTarget;
        if (currentTarget != null&&targetFollower.TargetInRange())
        {
            Fire(); 
        }
    }

    private void Fire()
    {
        fireRateTimer -=Time.deltaTime;
        if (fireRateTimer < 0)
        {
            //Fire mechanic
            GameObject createdProjectile =Instantiate(projectile, firePoint.position, firePoint.transform.rotation);
            Rigidbody2D rigidbody2D= createdProjectile.GetComponent<Rigidbody2D>();
            float targetAngle = targetFollower.LookAngle();
            Vector2 forceDir = new Vector2(Mathf.Cos(targetAngle * Mathf.Deg2Rad), Mathf.Sin(targetAngle * Mathf.Deg2Rad));
            rigidbody2D.AddForce(forceDir * projectilePushForce, ForceMode2D.Impulse);

            fireRateTimer = fireRateTimerMax;
        }
    }
}
