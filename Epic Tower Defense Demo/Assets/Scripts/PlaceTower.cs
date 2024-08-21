using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] private Transform[] cantTouchThis;

    [SerializeField] private Tilemap tilemap;
    [SerializeField] private GameObject tower;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(tower, GetSelectTile(), Quaternion.identity);
        }

    }
    private Vector3 GetSelectTile()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);
        Vector3 cellCenterWorlPos = tilemap.GetCellCenterWorld(cellPosition);
       // TileBase selectedTile=tilemap.GetTile(cellPosition);
        return cellCenterWorlPos;
    }

    
}
