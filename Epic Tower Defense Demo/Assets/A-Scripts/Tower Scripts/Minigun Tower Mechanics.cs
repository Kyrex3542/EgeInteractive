using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunTowerMechanics : TowerMechanics
{
    [SerializeField] private Transform firePoint2;
    private bool fireOtherBarrel=false;
    protected override void PerformAction()
    {
        Fire();
    }
    protected override void Fire()
    {
        if (fireRateTimer < 0)
        {
            GameObject createdProjectile;
            if (fireOtherBarrel) 
            {
                createdProjectile = Instantiate(projectile, firePoint.position, firePoint.transform.rotation);
                fireOtherBarrel = !fireOtherBarrel;
            }
            else
            {
                 createdProjectile = Instantiate(projectile, firePoint2.position, firePoint2.transform.rotation);
                fireOtherBarrel = !fireOtherBarrel;
            }
            if (createdProjectile == null) return;
            ProjectileBehavior projectileBehavior = createdProjectile.GetComponent<ProjectileBehavior>();
            projectileBehavior.moveSpeed = 30;
            projectileBehavior.damage = damage;
            projectileBehavior.target = currentTarget.transform;

            fireRateTimer = fireRateTimerMax;
        }
    }
}
