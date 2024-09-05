using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunTowerMechanics : TowerMechanics
{
    [SerializeField] private float stunDuration;

    protected override void PerformAction()
    {
        Stun();
    }
    protected override void Update()
    {
        
        if (targetFollower.Targets().Count>0)
        {
            PerformAction();
        }
    }

    private void Stun()
    {
        fireRateTimer -= Time.deltaTime;
        if (fireRateTimer < 0)
        {
            List<GameObject> targets = targetFollower.Targets();
            foreach (GameObject target in targets)
            {
               PathFinder pathFinder= target.GetComponent<PathFinder>();
                pathFinder.StunMe(stunDuration, 0);
            }
            fireRateTimer = fireRateTimerMax;
        }
    }

}
