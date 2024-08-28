using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public float damage;

    public enum Type
    {
        railgun,//D��mana �arpt���nda delip ge�ecek
        rocket,//�arpt���nda belirli bir alana hasar vuracak
        tesla,//leveline g�re belirli say�da d��mana sekecek
        poison,//T�m haritaya s�rekli hasar  verecek
        bone,//Z�rha iki kat vuracak
        bulldozer,//T�m haritaya hasar verecek
        sniper//Gidilen mesafeye ba�l� damage artacak
    }
    public Type type;
    private void Update()
    {
        if (target != null)
            MoveToTarget();
        else
            Destroy(gameObject);
        switch (type)
        {
            case Type.railgun:
                Debug.Log("Railgun");
                break;
            case Type.rocket:
                Debug.Log("Rocket");
                break;
            case Type.tesla:

                break;
            case Type.poison:

                break;
            case Type.bone:

                break;
            case Type.bulldozer:

                break;
            case Type.sniper:

                break;
        }

    }
    private void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        float targetAngle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetAngle + -90f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthManager>(out HealthManager healthManager))
        {
            healthManager.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
