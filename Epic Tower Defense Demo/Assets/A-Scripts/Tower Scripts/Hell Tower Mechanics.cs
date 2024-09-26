using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellTowerMechanics : TowerMechanics
{
    [SerializeField]private LineRenderer lineRenderer;
    [SerializeField] private float additionalDamageOverTime;
    [SerializeField] private float currentDamage;
    [SerializeField] private float maxDamage;
    private HealthManager enemyHealthManager;
    protected override void Start()
    {
        base.Start();
        currentDamage = damage;
        lineRenderer.enabled = false;
    }
    protected override void PerformAction()
    {
        Fire();
    }
    protected override void Update()
    {
        fireRateTimer -= Time.deltaTime;
        if(currentTarget != targetFollower.currentTarget)
        {
            currentTarget=targetFollower.currentTarget;
            currentDamage= damage;
            enemyHealthManager = currentTarget != null ? currentTarget.GetComponent<HealthManager>() : null;
        }
        if (currentTarget != null)
        {
            lineRenderer.enabled = true;
            PerformAction();
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
    protected override void Fire()
    {
        if (currentTarget == null || enemyHealthManager == null) return;
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, currentTarget.transform.position);

        if (fireRateTimer <= 0)
        {
            enemyHealthManager.TakeDamage(currentDamage);
            currentDamage = Mathf.Min(currentDamage + additionalDamageOverTime, maxDamage);
            fireRateTimer = fireRateTimerMax;
        }
    }

}
