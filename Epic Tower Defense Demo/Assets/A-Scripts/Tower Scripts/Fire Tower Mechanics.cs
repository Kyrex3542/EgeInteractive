using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTowerMechanics : TowerMechanics
{
    protected override void PerformAction()
    {
        Fire();
    }
}
