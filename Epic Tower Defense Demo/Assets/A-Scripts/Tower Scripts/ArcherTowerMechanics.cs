using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTowerMechanics : TowerMechanics
{
    protected override void PerformAction()
    {
        Fire();
    }

}
