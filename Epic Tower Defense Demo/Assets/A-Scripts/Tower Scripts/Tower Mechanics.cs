using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerMechanics : MonoBehaviour
{
    public bool isTowerActive=false;
    public int towerIndex;
    [SerializeField] protected TargetFollower targetFollower;
    [SerializeField] protected GameObject currentTarget;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected GameObject projectile;
    [SerializeField] protected float projectilePushForce;
    [SerializeField] protected CircleCollider2D circleCollider2D;

    [Header("Weapon Properties")]
    [SerializeField] protected float damage;
    [SerializeField] protected float range;
    [SerializeField, Tooltip("Rounds Per Second")] protected float fireRate;

    protected float fireRateTimerMax;
    protected float fireRateTimer;

    protected virtual void Start()
    {
        
        fireRateTimerMax = 1 / fireRate;
        circleCollider2D.radius = range;
        fireRateTimer = fireRateTimerMax;
    }

    protected virtual void Update()
    {
        fireRateTimer -= Time.deltaTime;
        currentTarget = targetFollower.currentTarget;
        if (currentTarget != null && targetFollower.TargetInRange())
        {
            PerformAction();
        }
    }

    protected abstract void PerformAction();

    protected virtual void Fire()
    {
        if (fireRateTimer <= 0)
        {
            GameObject createdProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
            ProjectileBehavior projectileBehavior = createdProjectile.GetComponent<ProjectileBehavior>();
            projectileBehavior.moveSpeed = projectilePushForce;
            projectileBehavior.damage = damage;
            projectileBehavior.target = currentTarget.transform;
            SetProjectileType(projectileBehavior);
            fireRateTimer = fireRateTimerMax;
        }
    }

    protected virtual void SetProjectileType(ProjectileBehavior projectileBehavior)
    {
    }
    public virtual void Upgrade(float newDamage, float newRange, float newFireRate)
    {
        damage = newDamage;
        range = newRange;
        fireRate = newFireRate;

        fireRateTimerMax = 1 / fireRate;
        if (circleCollider2D != null)
        {
            circleCollider2D.radius = range;
        }
        Debug.Log("Succesful Upgrade");
        Debug.Log("Damage :"+damage+" Range: "+range + " Fire Rate: "+fireRate);
    }
}
