using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithTowerMechanics : TowerMechanics 
{

    protected override void PerformAction()
    {
        MakeMoney();
    }

    private void MakeMoney()
    {
        Player.Instance.GainGold((int)damage);
        fireRateTimer = fireRateTimerMax; 
    }

    protected override void Start()
    {
        fireRateTimerMax = 1 / fireRate;
        fireRateTimer = fireRateTimerMax;
    }

    protected override void Update()
    {
        fireRateTimer -= Time.deltaTime;

        if (fireRateTimer <= 0)
        {
            PerformAction();
        }
    }

    public override void Upgrade(float newDamage, float newRange, float newFireRate)
    {
        damage = newDamage;
        fireRate = newFireRate;

        fireRateTimerMax = 1 / fireRate;
        Debug.Log("Successful Upgrade");
        Debug.Log("Money Gain: " + damage + " Money Gain Rate: " + fireRate);
    }

}
