using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public float Delay = 1f;

    private void Start()
    {
        HealthBar.fillAmount = HealthAmount / maxHealth;
        ShieldBar.fillAmount = ShieldAmount / maxShield;
    }
    void Update()
    {
        if (HealthAmount <= 0)
        {
            MobIsDying();
        }
        if (ShieldAmount <= 0)
        {
            ShieldBar.gameObject.SetActive(false);
        }
    }

    private void MobIsDying()
    {
        Delay -= Time.deltaTime;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<PathFinder>().enabled = false;
        gameObject.GetComponentInChildren<Canvas>().enabled = false;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.eulerAngles.z, -90f, 15f * Time.deltaTime)));
        if (Delay <= 0)
        {
            Player.Instance.GainGold(GoldReward);
            Destroy(gameObject);
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
                TakeDamage(damage - ShieldAmount);
            }
        }
    }
}
