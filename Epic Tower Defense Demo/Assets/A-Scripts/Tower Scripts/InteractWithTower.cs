using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithTower : MonoBehaviour
{
    public int sellValue;
    public int upgradeValue;
    [SerializeField] private TowerMechanics tower;

    [Header("Upgrade Properties Level 2")]
    [SerializeField] private float damage2;
    [SerializeField] private float range2;
    [SerializeField, Tooltip("Round Per Second")] private float fireRate2;
    [SerializeField] private int sellValue2;
    [SerializeField] private int upgradeValue2;

    [Header("Upgrade Properties Level 3")]
    [SerializeField] private float damage3;
    [SerializeField] private float range3;
    [SerializeField, Tooltip("Round Per Second")] private float fireRate3;
    [SerializeField] private int sellValue3;
    private int upgradeLevel = 1;
    public void GetTowerValues(out int upgradeValue, out int sellValue)
    {
        sellValue = this.sellValue;
        upgradeValue=this.upgradeValue;
    }
    public void UpgradeTower()
    {
        if(Player.Instance.GetPlayerCurrentGold()>=upgradeValue)
        {
            upgradeLevel++;
            Player.Instance.SpendGold(upgradeValue);
        }
        
        if (upgradeLevel == 2)
        {
            tower.Upgrade(damage2, range2, fireRate2);
            sellValue =sellValue2;
            upgradeValue =upgradeValue2;
        }
        else if(upgradeLevel == 3) 
        {
            tower.Upgrade(damage3, range3, fireRate3);
            sellValue = sellValue3;
        }
    }
}
