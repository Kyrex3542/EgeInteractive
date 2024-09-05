using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunTowerMechanics : TowerMechanics
{
    protected override void PerformAction()
    {
        Fire();
    }
    protected override void SetProjectileType(ProjectileBehavior projectileBehavior)
    {
        projectileBehavior.type = ProjectileBehavior.Type.railgun;
    }
}
