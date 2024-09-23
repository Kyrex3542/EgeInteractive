using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [Header("Bar Images")]
    public Image HealthBar;
    public Image ShieldBar;

    [Header("Max Shield & Health Amount")]
    public float maxHealth;
    public float maxShield;

    [Header("Normal Shield & Health Amount")]
    public float HealthAmount;
    public float ShieldAmount;

    [Header("Extra")]
    public int GoldReward = 0;
    public float Delay = 1f;

    [Header("Don't Touch")]
    [SerializeField] private int MobNumber;
    //Ýstatistiklere girmek için moblarýn numarasý.

    private PlayerStatistics PlayerStatistics;

    private void Start()
    {
        PlayerStatistics = FindFirstObjectByType<PlayerStatistics>();
        HealthBar.fillAmount = HealthAmount / maxHealth;
        ShieldBar.fillAmount = ShieldAmount / maxShield;
    }
    void Update()
    {
        if (HealthAmount <= 0)
        {
            Destroy(gameObject);

           // MobIsDying();
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

            PlayerStatistics.EnemyCount(MobNumber);
            PlayerStatistics.CoinEarned(GoldReward);
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
