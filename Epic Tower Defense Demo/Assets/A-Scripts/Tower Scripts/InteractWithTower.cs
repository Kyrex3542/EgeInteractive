using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InteractWithTower : MonoBehaviour
{
    public int sellValue;
    public int upgradeValue;
    [SerializeField] private TowerMechanics tower;
    public UIManager manager;

    public List<UpgradeTiers> upgradeTiers;
    public int upgradeLevel = -1;

    [System.Serializable]
    public class UpgradeTiers
    {
        public float damage;
        public float range;
        [SerializeField, Tooltip("Round Per Second")] public float fireRate;
        public int sellValue;
        public int upgradeValue;
    }
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
            Debug.Log(upgradeLevel + " " + upgradeTiers.Count);
            tower.Upgrade(upgradeTiers[upgradeLevel].damage, upgradeTiers[upgradeLevel].range, upgradeTiers[upgradeLevel].fireRate);
            sellValue = upgradeTiers[upgradeLevel].sellValue;
            upgradeValue=upgradeTiers[upgradeLevel].upgradeValue;
        }
        if (upgradeLevel == upgradeTiers.Count-1)
        {
            //Max upgrade, disable upgrade menu and show its maxedout
            Debug.Log("Button disabled");
            manager.upgradeBtn.gameObject.SetActive(false);
        }
    }
}
