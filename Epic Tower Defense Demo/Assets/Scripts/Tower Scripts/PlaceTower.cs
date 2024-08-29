using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] private Transform[] cantTouchThis;
    [SerializeField] private GameObject sliderTowerMenu;

    [SerializeField] private MapLoader mapLoader;
    [SerializeField] private Tilemap activeMap;
    [SerializeField] private Tilemap activeMapShadow;
    [SerializeField] private GameObject tower;
    private Vector3 cellCenterWorlPos = default;

    [Header("Tower Prefabs")]
    [SerializeField] private GameObject bowTower;
    [SerializeField] private GameObject cannonTower;
    [SerializeField] private GameObject rocketTower;
    [SerializeField] private GameObject minigunTower;
    [SerializeField] private GameObject sniperTower;
    [SerializeField] private GameObject shotgunTower;
    [SerializeField] private GameObject railgunTower;
    [SerializeField] private GameObject blacksmithTower;
    [SerializeField] private GameObject stunTower;
    [SerializeField] private GameObject hellTower;
    [SerializeField] private GameObject teslaTower;
    [SerializeField] private GameObject poisonTower;
    [SerializeField] private GameObject boneTower;
    private List<Vector3Int> busyTiles;
    private bool canPlaceTower = false;
    private Vector3Int selectedCellPosition;
    void Start()
    {
        activeMap = mapLoader.activeMap;
        activeMapShadow = mapLoader.activeMapShadow;
        busyTiles = new List<Vector3Int>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (CanPlaceTower())
            {
                if (!IsPointerOverUIObject())
                {
                    ShowSliderTowerMenu();
                }

            }

        }

    }
    private void ShowSliderTowerMenu()
    {
        sliderTowerMenu.SetActive(true);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 100;
        sliderTowerMenu.transform.position = mousePos;

        selectedCellPosition = activeMap.WorldToCell(mousePos);
        cellCenterWorlPos = activeMap.GetCellCenterWorld(selectedCellPosition);
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    private Vector3 GetSelectTile()
    {

        if (canPlaceTower || !canPlaceTower)
        {
            busyTiles.Add(selectedCellPosition);
        }
        // TileBase selectedTile=tilemap.GetTile(cellPosition);
        return cellCenterWorlPos;
    }
    private bool CanPlaceTower()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = activeMap.WorldToCell(mouseWorldPos);
        TileBase tileShadow = activeMapShadow.GetTile(cellPosition);

        foreach (Vector3Int busyTile in busyTiles)
        {
            if (busyTile == cellPosition)
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
            canPlaceTower = false;
        }
        return canPlaceTower;
    }
    public void PlaceBowTower()
    {
        Instantiate(bowTower, GetSelectTile(), Quaternion.identity);
        sliderTowerMenu.SetActive(false);
    }
    public void PlaceRocketTower()
    {
        Instantiate(rocketTower, GetSelectTile(), Quaternion.identity);
        sliderTowerMenu.SetActive(false);
    }
    public void PlaceMinigunTower()
    {
        Instantiate(minigunTower, GetSelectTile(), Quaternion.identity);
        sliderTowerMenu.SetActive(false);
    }
    public void PlaceCannonTower()
    {
        Instantiate(cannonTower, GetSelectTile(), Quaternion.identity);
        sliderTowerMenu.SetActive(false);
    }
    public void PlaceSniperTower()
    {
        Instantiate(sniperTower, GetSelectTile(), Quaternion.identity);
        sliderTowerMenu.SetActive(false);
    }
    public void PlaceShotgunTower()
    {
        Instantiate(shotgunTower, GetSelectTile(), Quaternion.identity);
        sliderTowerMenu.SetActive(false);
    }
    public void PlaceRailgunTower()
    {
        Instantiate(railgunTower, GetSelectTile(), Quaternion.identity);
        sliderTowerMenu.SetActive(false);
    }
    public void PlaceBlacksmithTower()
    {
        Instantiate(blacksmithTower, GetSelectTile(), Quaternion.identity);
        sliderTowerMenu.SetActive(false);
    }
    public void PlaceStunTower()
    {
        Instantiate(stunTower, GetSelectTile(), Quaternion.identity);
        sliderTowerMenu.SetActive(false);
    }
    public void PlaceHellTower()
    {
        Instantiate(hellTower, GetSelectTile(), Quaternion.identity);
        sliderTowerMenu.SetActive(false);
    }
    public void PlaceTeslaTower()
    {
        Instantiate(teslaTower, GetSelectTile(), Quaternion.identity);
        sliderTowerMenu.SetActive(false);
    }
    public void PlacePoisonTower()
    {
        Instantiate(poisonTower, GetSelectTile(), Quaternion.identity);
        sliderTowerMenu.SetActive(false);
    }
    public void PlaceBoneTower()
    {
        Instantiate(boneTower, GetSelectTile(), Quaternion.identity);
        sliderTowerMenu.SetActive(false);
    }

}
