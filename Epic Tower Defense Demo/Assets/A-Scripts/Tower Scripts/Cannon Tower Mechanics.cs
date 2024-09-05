using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTowerMechanics : TowerMechanics
{
    protected override void PerformAction()
    {
        Fire();
    }
}
