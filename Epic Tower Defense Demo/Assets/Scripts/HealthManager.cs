using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image HealthBar;
    public float HealthAmount = 100f;

    void Update()
    {
        if (HealthAmount <= 0)
            Destroy(transform.parent.gameObject);
    }

    void TakeDamage(float damage)
    {
        HealthAmount -= damage;
        HealthBar.fillAmount = HealthAmount / 100f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ammo"))
        {
            TakeDamage(5);
        }
    }
}
