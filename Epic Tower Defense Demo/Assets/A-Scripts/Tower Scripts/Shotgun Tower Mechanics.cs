using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunTowerMechanics : TowerMechanics
{
    protected override void PerformAction()
    {
        Fire();
    }
}
