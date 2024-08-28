using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunTowerMechanics : MonoBehaviour
{
    [SerializeField] private TargetFollower targetFollower;

    [SerializeField] private CircleCollider2D circleCollider2D;

    [Header("Weapon Properties")]
    [SerializeField] private float stunDuration;
    [SerializeField] private float range;
    [SerializeField, Tooltip("Stun Per Second")] private float stunRate;

    private float stunRateTimerMax = 5;
    private float stunRateTimer = 0;
    private void Start()
    {
        stunRateTimerMax = 1 / stunRate;
        circleCollider2D.radius = range;
        targetFollower.canTurnToEnemy = false;
    }
    private void Update()
    {
        
        if (targetFollower.Targets().Count>0)
        {
            Stun();
        }
    }

    private void Stun()
    {
        stunRateTimer -= Time.deltaTime;
        if (stunRateTimer < 0)
        {
            List<GameObject> targets = targetFollower.Targets();
            foreach (GameObject target in targets)
            {
               PathFinder pathFinder= target.GetComponent<PathFinder>();
                pathFinder.StunMe(stunDuration, 0);
            }
            stunRateTimer = stunRateTimerMax;
        }
    }

}
