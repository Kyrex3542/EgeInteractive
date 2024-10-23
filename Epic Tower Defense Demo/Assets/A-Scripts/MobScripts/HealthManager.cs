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
    private bool _isMobDying = false;
    //Ýstatistiklere girmek için moblarýn numarasý.

    private PlayerStatistics PlayerStatistics;

    private void Start()
    {
        PlayerStatistics = FindFirstObjectByType<PlayerStatistics>();
        HealthBar.fillAmount = float.IsNaN(HealthAmount / maxHealth) ? HealthBar.fillAmount : HealthAmount / maxHealth;
        ShieldBar.fillAmount = float.IsNaN(ShieldAmount / maxShield) ? ShieldBar.fillAmount : ShieldAmount / maxShield;
    }
    void Update()
    {
        if (HealthAmount <= 0)
        {
            Delay -= Time.deltaTime;
            if (Delay <= 0)
            {
                MobDied();
            }
        }
    }

    private void MobIsDying()
    {
        if (gameObject.CompareTag("Obstacle"))//Sadece Obstacle de çalışacak
        {
            ObstacleTarget.instance.HidePointer();
        }
        _isMobDying = true;
        if(gameObject.TryGetComponent<PathFinder>(out PathFinder pathFinder))
        {
            pathFinder.enabled = false;
        }
        gameObject.GetComponentInChildren<Canvas>().enabled = false;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.eulerAngles.z, -90f, 15f * Time.deltaTime)));
    }
    private void MobDied()
    {

        PlayerStatistics.EnemyCount(MobNumber);
        PlayerStatistics.CoinEarned(GoldReward);
        Player.Instance.GainGold(GoldReward);
        Player.Instance.playerkillCountStatistic++;
        Destroy(gameObject);
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
        if (HealthAmount <= 0)
        {
            MobIsDying();
        }
        if (ShieldAmount <= 0&&ShieldBar!=HealthBar)
        {
            ShieldBar.gameObject.SetActive(false);
        }
    }
    public bool isMobDying()
    {
        return _isMobDying;
    }
}
