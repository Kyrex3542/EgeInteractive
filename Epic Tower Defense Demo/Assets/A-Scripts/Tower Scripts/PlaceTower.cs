using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] private GameObject sliderTowerMenu;
    [SerializeField]private UIManager uiManager;

    [SerializeField] private MapLoader mapLoader;
    [SerializeField] public Tilemap activeMap;
    [SerializeField] private Tilemap activeMapShadow;
    [SerializeField] private GameObject tower;
    private Vector3 cellCenterWorlPos = default;

    [Header("Tower Prefabs")]
    [SerializeField] private GameObject archerTower;
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
    [SerializeField] private GameObject buldozerTower;
    [SerializeField] private GameObject freezeTower;
    [SerializeField] private GameObject alienTower;
    [SerializeField] private GameObject fireTower;
    [SerializeField] private GameObject bloodTower;



    [SerializeField] private ObstacleTarget obstacleTarget;
    [SerializeField] private GameObject gridPointer;

    private List<TowerData> busyTiles;
    private Vector3Int selectedCellPosition;
    private bool isMenusActive = false;
    void Start()
    {
        activeMap = mapLoader.activeMap;
        activeMapShadow = mapLoader.activeMapShadow;
        busyTiles = new List<TowerData>();

    }
    void LateUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            obstacleTarget.SetTargetObstacle();
            if ( CanPlaceTower())
            {
                if (!IsPointerOverUIObject() && !obstacleTarget.isObstacleSelected())
                {
                    if (!isMenusActive) 
                    {
                        ShowSliderTowerMenu();
                        uiManager.Hide_InteractionMenu();
                        isMenusActive = !isMenusActive;
                    }
                    else
                    {
                        uiManager.Hide_InteractionMenu();
                        gridPointer.SetActive(false);
                        sliderTowerMenu.SetActive(false);
                        isMenusActive=!isMenusActive;
                    }
                    
                }

            }

        }

    }
    private void ShowSliderTowerMenu()
    {
        sliderTowerMenu.SetActive(true);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 100;
        gridPointer.SetActive(true);
        

        selectedCellPosition = activeMap.WorldToCell(mousePos);
        cellCenterWorlPos = activeMap.GetCellCenterWorld(selectedCellPosition);
        gridPointer.transform.position = cellCenterWorlPos;
        mousePos = cellCenterWorlPos;
        if (mousePos.y > -1)
        {
            mousePos.y -= 2;
        }
        else
        {
            mousePos.y += 2;
        }
        mousePos.x+=.6f;
        sliderTowerMenu.transform.position = mousePos;
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
        return cellCenterWorlPos;
    }
    
    private bool CanPlaceTower()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = activeMap.WorldToCell(mouseWorldPos);
        TileBase tileShadow = activeMapShadow.GetTile(cellPosition);

        foreach (TowerData busyTile in busyTiles)
        {
            if (busyTile.Position == cellPosition)
            {
                return false;
            }
        }
        if (tileShadow == null)
        {
            return true;
        }
        if (tileShadow.name == "normal_7")
        {
            return false;
        }
        return false;
    }

    #region PlaceTower
    public void PlaceArcherTower()
    {
        PlaceTowerAtPosition(archerTower);
    }
    public void PlaceRocketTower()
    {
        PlaceTowerAtPosition(rocketTower);
    }
    public void PlaceMinigunTower()
    {
        PlaceTowerAtPosition(minigunTower);
    }
    public void PlaceCannonTower()
    {
        PlaceTowerAtPosition(cannonTower);
    }
    public void PlaceSniperTower()
    {
        PlaceTowerAtPosition(sniperTower);
    }
    public void PlaceShotgunTower()
    {
        PlaceTowerAtPosition(shotgunTower);
    }
    public void PlaceRailgunTower()
    {
        PlaceTowerAtPosition(railgunTower);
    }
    public void PlaceBlacksmithTower()
    {
        PlaceTowerAtPosition(blacksmithTower);
    }
    public void PlaceStunTower()
    {
        PlaceTowerAtPosition(stunTower);
    }
    public void PlaceHellTower()
    {
        PlaceTowerAtPosition(hellTower);
    }
    public void PlaceTeslaTower()
    {
        PlaceTowerAtPosition(teslaTower);
    }
    public void PlacePoisonTower()
    {
        PlaceTowerAtPosition(poisonTower);
    }
    public void PlaceBoneTower()
    {
        PlaceTowerAtPosition(boneTower);
    }
    public void PlaceBuldozerTower()
    {
        PlaceTowerAtPosition(buldozerTower);
    }
    public void PlaceFreezeTower()
    {
        PlaceTowerAtPosition(freezeTower);
    }
    public void PlaceAlienTower()
    {
        PlaceTowerAtPosition(alienTower);
    }
    public void PlaceBloodTower()
    {
        PlaceTowerAtPosition(bloodTower);
    }
    public void PlaceFireTower()
    {
        PlaceTowerAtPosition(fireTower);
    }
    #endregion
    private void PlaceTowerAtPosition(GameObject towerPrefab)
    {
        GameObject createdTower= Instantiate(towerPrefab, GetSelectTile(), Quaternion.identity);
        createdTower.GetComponent<InteractWithTower>().manager = uiManager;
        busyTiles.Add(new TowerData(selectedCellPosition, createdTower));
        sliderTowerMenu.SetActive(false);
    }
    public List<TowerData> GetBusyTileData()
    {
        return busyTiles;
    }
    public void RemoveTower(TowerData removeTowerData,int sellValue)
    {
        Player.Instance.GainGold(sellValue);
        busyTiles.Remove(removeTowerData);
        Destroy(removeTowerData.TowerPrefab);
        uiManager.Hide_InteractionMenu();
    }
    public void UpgradeTower(TowerData towerData)
    {
        if (towerData.TowerPrefab.TryGetComponent<InteractWithTower>(out InteractWithTower towerMechanics))
        {
            towerMechanics.UpgradeTower();
        }
    }
}
