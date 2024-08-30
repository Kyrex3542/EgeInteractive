using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class TowerInteraction : MonoBehaviour
{
    [SerializeField] PlaceTower placeTower;
    [SerializeField] UIManager UImanager;
    private TowerData selectedTower;
    private InteractWithTower interactWithTower;
    private void Start()
    {
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0)&& !IsPointerOverUIObject())
        {
            SelectTower();
        }
    }
    private void SelectTower()
    {
        List<TowerData> towerDatas = placeTower.GetBusyTileData();
        Vector3 mouseWorldPos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = placeTower.activeMap.WorldToCell(mouseWorldPos);

        foreach (TowerData data in towerDatas)
        {
            if (data.Position == cellPosition)
            {
        Debug.Log("q");
                Show_InteractionMenu(data);
                selectedTower = data;
                break;
            }
        }
    }
    private void Show_InteractionMenu(TowerData towerData)
    {
        if (towerData.TowerPrefab.gameObject.TryGetComponent<InteractWithTower>(out interactWithTower))
        {
            UImanager.Show_InteractionMenu(interactWithTower.upgradeValue, interactWithTower.sellValue);
        }
    }

    public void RemoveTower()
    {
        if(interactWithTower != null)
        {
            placeTower.RemoveTower(selectedTower, interactWithTower.sellValue);
        }
    }
    public void UpgradeTower()
    {

    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
