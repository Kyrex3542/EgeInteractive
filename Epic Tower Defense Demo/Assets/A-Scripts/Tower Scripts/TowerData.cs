using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData
{
    public Vector3Int Position { get; private set; }
    public GameObject TowerPrefab { get; private set; }

    public TowerData(Vector3Int position, GameObject towerPrefab)
    {
        Position = position;
        TowerPrefab = towerPrefab;
    }
}
