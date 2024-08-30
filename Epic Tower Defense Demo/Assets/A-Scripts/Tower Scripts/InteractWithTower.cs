using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithTower : MonoBehaviour
{
    public int sellValue;
    public int upgradeValue;
    public void GetTowerValues(out int upgradeValue, out int sellValue)
    {
        sellValue = this.sellValue;
        upgradeValue=this.upgradeValue;
    }
}
