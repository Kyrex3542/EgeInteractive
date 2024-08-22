using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] private Transform[] cantTouchThis;

    [SerializeField] private Tilemap tileMapLevel1;
    [SerializeField] private Tilemap tileMapLevel1Shadow;
    [SerializeField] private GameObject tower;
    private List<Vector3Int> busyTiles;
    private bool canPlaceTower=false;
    void Start()
    {
        busyTiles=new List<Vector3Int>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (CanPlaceTower())
            {
                Instantiate(tower, GetSelectTile(), Quaternion.identity);
            }

        }

    }
    private Vector3 GetSelectTile()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = tileMapLevel1.WorldToCell(mouseWorldPos);
        Vector3 cellCenterWorlPos = tileMapLevel1.GetCellCenterWorld(cellPosition);
        TileBase tile = tileMapLevel1.GetTile(cellPosition);
        Debug.Log(tile);
        if (canPlaceTower)
        {
            busyTiles.Add(cellPosition);
        }
       // TileBase selectedTile=tilemap.GetTile(cellPosition);
        return cellCenterWorlPos;
    }
    private bool CanPlaceTower()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = tileMapLevel1.WorldToCell(mouseWorldPos);
        TileBase tileShadow = tileMapLevel1Shadow.GetTile(cellPosition);

        foreach (Vector3Int busyTile in busyTiles)
        {
            if(busyTile == cellPosition)
            {
                canPlaceTower = false;
                return canPlaceTower;
            }
        }
        if (tileShadow == null)
        {
            canPlaceTower = true;
            return canPlaceTower;
        }
            if (tileShadow.name == "normal_7")
        {
            Debug.Log(tileShadow.name);
            canPlaceTower = false;
        }
        return canPlaceTower;
    }

    
}
