using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public float damage;
    public float rocketAreaOfEffectRadius;
    public float teslaChainRange;
    public int teslaMaxChain;
    public float boneDamageMultiplier = 2f; 
    public float distanceDamageMultiplier = 0.1f; 
    private Vector2 firstDir;
    private bool hasHitEnemy = false;
    //For Tesla
    private List<Transform> teslaHitTargets = new List<Transform>();
    private int currentChainCount = 0;
    private float closestEnemy=Mathf.Infinity;

    private Vector3 firstPos; 
    public enum Type
    {
        None,
        railgun,    //Düþmana çarptýðýnda delip geçecek
        rocket,     //çarptýðýnda belirli bir alana hasar vuracak
        tesla,      //leveline göre belirli sayýda düþmana sekecek
        bone,       //Zırha iki kat vuracak
        sniper      //Gidilen mesafeye baðlý damage artacak
    }
    public Type type;
    private void Start()
    {
        firstPos = transform.position;
        firstDir = (target.position - transform.position).normalized;

    }
    private void Update()
    {
        if (target != null || (type == Type.railgun && hasHitEnemy))
        {
            MoveToTarget();
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void MoveToTarget()
    {
        if (type == Type.railgun && hasHitEnemy && firstDir!=Vector2.zero)
        {
            transform.position += (Vector3)firstDir * moveSpeed * Time.deltaTime;

        }
        else if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            float targetAngle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetAngle + -90f));        
        }
        else
        {
            
                Destroy(gameObject);
            
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthManager>(out HealthManager healthManager))
        {
                    hasHitEnemy = true;
            switch (type)
            {
                case Type.railgun:
                    healthManager.TakeDamage(damage);
                    break;
                case Type.rocket:
                    Explode();
                    break;
                case Type.tesla:
                    ChainLightning(collision.transform);
                    break;
                case Type.bone:
                    BoneDamage(collision.transform);
                    break;
                case Type.sniper:
                    float traveledDistance = Vector2.Distance(firstPos, transform.position);
                    healthManager.TakeDamage(damage + (traveledDistance * distanceDamageMultiplier));
                    break;
                case Type.None:
                    healthManager.TakeDamage(damage);
                    Destroy(gameObject);
                    break;
            }
        }
    }
    private void BoneDamage(Transform target)
    {
        if (target.TryGetComponent<HealthManager>(out HealthManager healthManager))
        {
            if (healthManager.ShieldAmount > 0)
            {
                healthManager.TakeDamage(damage * boneDamageMultiplier);
            }
            else
            {
                healthManager.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
    private void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, rocketAreaOfEffectRadius);
        foreach (Collider2D hit in colliders)
        {
            if (hit.TryGetComponent<HealthManager>(out HealthManager healthManager))
            {
                healthManager.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
    private void ChainLightning(Transform _teslaTarget)
    {/*
        closestEnemy = Mathf.Infinity;
        Transform tempEnemyHolder = _teslaTarget;
        Hit(_teslaTarget.gameObject, damage);
        currentChainCount++;
        Collider2D[] collider2D = Physics2D.OverlapCircleAll(_teslaTarget.position, teslaChainRange);
        foreach (Collider2D hit2 in collider2D)
        {
            if (_teslaTarget!=hit2.transform && hit2.CompareTag("Enemy"))
            {
                float distanceToOtherEnemy = Vector2.Distance(_teslaTarget.position, hit2.transform.position);
                if (distanceToOtherEnemy < closestEnemy)
                {
                    closestEnemy = distanceToOtherEnemy;
                    tempEnemyHolder = hit2.transform;
                }
            }
        }

        if (tempEnemyHolder != _teslaTarget)
        {
            target = tempEnemyHolder;
            if (currentChainCount >= teslaMaxChain) 
            {
                Destroy(gameObject); 
            }

        }
        else
        {
            
            Destroy(gameObject);
        }
        */
        
        closestEnemy = Mathf.Infinity;
        Transform tempEnemyHolder=_teslaTarget;
        Hit(_teslaTarget.gameObject, damage);
        teslaHitTargets.Add(_teslaTarget);
        currentChainCount++;
        Debug.Log(currentChainCount);
        Collider2D[] collider2D = Physics2D.OverlapCircleAll(transform.position, teslaChainRange);
        if (currentChainCount >= teslaMaxChain||target==null){
            Destroy(gameObject);
        }
        foreach(Collider2D hit2 in collider2D)
        {
            if (!teslaHitTargets.Contains(hit2.transform) && hit2.CompareTag("Enemy"))
            {
                float distanceToOtherEnemy=Vector2.Distance(transform.position, hit2.transform.position);
                if (distanceToOtherEnemy < closestEnemy)
                {
                    closestEnemy = distanceToOtherEnemy;
                    tempEnemyHolder = hit2.transform;           
                }
            }
        }
        if (tempEnemyHolder != _teslaTarget)
        {
            target = tempEnemyHolder;
        }
        if (closestEnemy == Mathf.Infinity)
        {
            Destroy(gameObject);
        }
        
    }
    private void Hit(GameObject gameObject,float _damage)
    {
        if (gameObject.TryGetComponent<HealthManager>(out HealthManager healthManager))
        {
            healthManager.TakeDamage(_damage);
        }
    }
}
