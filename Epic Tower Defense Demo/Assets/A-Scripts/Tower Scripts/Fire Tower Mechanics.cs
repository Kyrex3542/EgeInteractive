using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTowerMechanics : TowerMechanics
{
    [Range (5f, 179f)]
    [SerializeField] private float coneAngle;
    protected override void PerformAction()
    {
        Fire();
    }
    protected override void Update()
    {
        fireRateTimer -= Time.deltaTime;
        currentTarget = targetFollower.currentTarget;
        if (currentTarget != null && targetFollower.TargetInRange())
        {
            PerformAction();
        }
    }
    protected override void Fire()
    {
        if (fireRateTimer <= 0)
        {
            ConeAttack();
            fireRateTimer = fireRateTimerMax;
        }
    }
    private void ConeAttack()
    {
        
        Collider2D[] hits = Physics2D.OverlapCircleAll(firePoint.position, range);
        Vector2 firePointDirection = firePoint.up; 

        foreach (Collider2D hit in hits)
        {
            Vector2 directionToTarget = (hit.transform.position - firePoint.position).normalized;

            
            float angleBetween = Vector2.Angle(firePointDirection, directionToTarget);
            if (angleBetween <= coneAngle / 2f)
            {
                if (hit.TryGetComponent<HealthManager>(out HealthManager healthManager))
                {
                    healthManager.TakeDamage(damage);
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (firePoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(firePoint.position, coneAngle); 

        Vector2 firePointDirection = firePoint.up;
        Vector3 leftBoundary = Quaternion.Euler(0, 0, coneAngle / 2) * firePointDirection;
        Vector3 rightBoundary = Quaternion.Euler(0, 0, -coneAngle / 2) * firePointDirection;

        Gizmos.DrawLine(firePoint.position, firePoint.position + leftBoundary * range);
        Gizmos.DrawLine(firePoint.position, firePoint.position + rightBoundary * range);
    }
}
