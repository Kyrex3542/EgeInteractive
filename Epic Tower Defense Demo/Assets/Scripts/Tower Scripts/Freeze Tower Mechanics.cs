using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTowerMechanics : MonoBehaviour
{
    [SerializeField] private TargetFollower targetFollower;

    [SerializeField] private CircleCollider2D circleCollider2D;

    [Header("Weapon Properties")]
    [SerializeField] private float slowDuration;
    [Range(0f, 1f)]
    [SerializeField] private float slowPercentage;
    [SerializeField] private float range;
    [SerializeField, Tooltip("Stun Per Second")] private float stunRate;

    private float stunRateTimerMax = 5;
    private float slowRateTimer = 0;
    private void Start()
    {
        stunRateTimerMax = 1 / stunRate;
        circleCollider2D.radius = range;
        targetFollower.canTurnToEnemy = false;
    }
    private void Update()
    {

        if (targetFollower.Targets().Count > 0)
        {
            Slow();
        }
    }

    private void Slow()
    {
        slowRateTimer -= Time.deltaTime;
        if (slowRateTimer < 0)
        {
            List<GameObject> targets = targetFollower.Targets();
            foreach (GameObject target in targets)
            {
                PathFinder pathFinder = target.GetComponent<PathFinder>();
                pathFinder.StunMe(slowDuration, slowPercentage);
            }
            slowRateTimer = stunRateTimerMax;
        }
    }
}
