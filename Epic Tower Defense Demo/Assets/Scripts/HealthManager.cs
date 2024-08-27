using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image HealthBar;
    public Image ShieldBar;
    public float HealthAmount = 100f;
    public float ShieldAmount = 100f;

    void Update()
    {
        if (HealthAmount <= 0)
        {
            Destroy(gameObject);
            Player.Instance.GainGold(5);
        }
    }

    public void TakeDamage(float damage)
    {
        if (ShieldAmount <= 0)
        {
            HealthAmount -= damage;
            HealthBar.fillAmount = HealthAmount / 100f;
        }
        else
        {
            ShieldAmount -= damage;
            ShieldBar.fillAmount = ShieldAmount / 100f;
        }
    }
}
