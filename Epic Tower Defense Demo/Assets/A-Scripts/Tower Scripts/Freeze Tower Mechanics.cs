using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTowerMechanics : TowerMechanics
{

    [SerializeField] private float slowDuration = 1;
    [SerializeField] private float slowPercentage = 1;
    protected override void PerformAction()
    {
        Slow();
    }
    protected override void Update()
    {

        if (targetFollower.Targets().Count > 0)
        {
            PerformAction();
        }
    }

    private void Slow()
    {
        fireRateTimer -= Time.deltaTime;
        if (fireRateTimer < 0)
        {
            List<GameObject> targets = targetFollower.Targets();
            foreach (GameObject target in targets)
            {
                PathFinder pathFinder = target.GetComponent<PathFinder>();
                pathFinder.StunMe(slowDuration, slowPercentage);
            }
            fireRateTimer = fireRateTimerMax;
        }
    }
}
