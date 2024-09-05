using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTowerMechanics : TowerMechanics
{
    protected override void PerformAction()
    {
        Fire();
    }
}
