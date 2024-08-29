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
    public float boneDamageMultiplier = 2f; // For bone type projectile
    public float distanceDamageMultiplier = 0.1f; // Damage increase per unit distance for sniper
    private Vector2 firstDir;
    private bool hasHitEnemy = false;

    private Vector3 firstPos; // For sniper damage calculation
    public enum Type
    {
        None,
        railgun,    //Düþmana çarptýðýnda delip geçecek
        rocket,     //çarptýðýnda belirli bir alana hasar vuracak
        tesla,      //leveline göre belirli sayýda düþmana sekecek
        bone,       //Zýrha iki kat vuracak
        sniper      //Gidilen mesafeye baðlý damage artacak
    }
    public Type type;
    private void Start()
    {
        firstPos = transform.position;

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
        if (type == Type.railgun && hasHitEnemy)
        {
            transform.position += (Vector3)firstDir * moveSpeed * Time.deltaTime;

        }
        else if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            float targetAngle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetAngle + -90f));
            if (type == Type.railgun)
            {
                firstDir = (target.position - transform.position).normalized;
            }
        }
        else
        {
            if (type != Type.railgun)
            {
                Destroy(gameObject);
            }
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthManager>(out HealthManager healthManager))
        {
            switch (type)
            {
                case Type.railgun:
                    healthManager.TakeDamage(damage);
                    hasHitEnemy = true;
                    break;
                case Type.rocket:
                    Explode();
                    break;
                case Type.tesla:
                    ChainLightning(collision.transform);
                    Debug.Log("1");

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
    private void ChainLightning(Transform firstTarget)
    {
        //Yapım aşamasında
        List<Transform> hitTargets = new List<Transform>();
        hitTargets.Add(firstTarget);
        int currentChains = 0;
        while (currentChains < teslaMaxChain)
        {

            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(firstTarget.position, teslaChainRange);
            bool chainFound = false;
            foreach (Collider2D hit2d in collider2Ds)
            {

                if (hit2d.TryGetComponent<HealthManager>(out HealthManager healthManager) && !hitTargets.Contains(hit2d.transform))
                {
                    Debug.Log("q");
                    healthManager.TakeDamage(damage);
                    hitTargets.Add(hit2d.transform);
                    firstTarget = hit2d.transform;
                    currentChains++;
                    chainFound = true;
                    break;
                }
            }
            if (!chainFound) break;
        }
    }
}
