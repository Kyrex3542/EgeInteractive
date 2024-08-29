using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image HealthBar;
    public Image ShieldBar;
    public float maxHealth;
    public float maxShield;
    public float HealthAmount;
    public float ShieldAmount;
    public int GoldReward = 0;

    private void Start()
    {
        HealthBar.fillAmount = HealthAmount / maxHealth;
        ShieldBar.fillAmount = ShieldAmount / maxShield;
    }
    void Update()
    {
        if (HealthAmount <= 0)
        {
            Destroy(gameObject);
            Player.Instance.GainGold(GoldReward);
        }
        if (ShieldAmount <= 0) {
            ShieldBar.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(float damage)
    {
        if (ShieldAmount <= 0)
        {
            HealthAmount -= damage;
            HealthBar.fillAmount = HealthAmount / maxHealth;
        }
        else
        {
            ShieldAmount -= damage;
            ShieldBar.fillAmount = ShieldAmount / maxShield;
            if (damage > ShieldAmount)
            {
                TakeDamage(damage-ShieldAmount);
            }
        }
    }
}
