using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuldozerTowerMechanics : TowerMechanics
{
    
    protected override void Start()
    {
        fireRateTimerMax = 1 / fireRate;
        circleCollider2D.radius = range;
    }
    protected override void Update()
    {
        currentTarget = targetFollower.currentTarget;
        if (currentTarget != null && targetFollower.TargetInRange())
        {
            PerformAction();
        }
    }
    protected override void PerformAction()
    {
        Fire();
    }
    protected override void Fire()
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
