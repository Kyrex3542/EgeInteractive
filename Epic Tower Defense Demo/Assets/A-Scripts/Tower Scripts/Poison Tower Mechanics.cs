
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonTowerMechanics : TowerMechanics
{
    protected override void PerformAction()
    {
        Fire();
    }
    protected override void Update()
    {
        currentTarget = targetFollower.currentTarget;
        if (currentTarget != null)
        {
            PerformAction();
        }
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
