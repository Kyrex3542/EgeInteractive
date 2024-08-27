using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLoader : MonoBehaviour
{
    [Header("Active Map")]
    public Tilemap activeMap;
    public Tilemap activeMapShadow;
    public Transform spawnPoint;
    public Transform targetPoint;
    [Header("Map List")]
    [SerializeField] private List<Tilemap> tileMaps;
    [SerializeField] private List<Tilemap> tileMapShadows;
    [SerializeField] private List<GameObject> pathsParentList;
    [SerializeField]private List<Transform> spawnPoints;
    [SerializeField]private List<Transform> targetPoints;
    [Header("Dont Change")]
    [SerializeField] private GameObject tileMapGrid;
    [SerializeField] private int mapNumber = 0;
    [SerializeField] private GameObject pathsParent;
    private void Awake()
    {
        mapNumber= PlayerPrefs.GetInt(Player.MAPNUMBERPLAYERPREFS,0);
        SetMapVariables();
    }
    public GameObject GetPathsParent()
    {
        return pathsParent;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetMapVariables();
        }
    }
    private void SetMapVariables()
    {
        if (mapNumber < tileMaps.Count && mapNumber < tileMapShadows.Count)
        {
            activeMap = tileMaps[mapNumber];
            activeMapShadow = tileMapShadows[mapNumber];
            pathsParent = pathsParentList[mapNumber];
            spawnPoint = spawnPoints[mapNumber];
            targetPoint = targetPoints[mapNumber];
            if (activeMap != null && activeMapShadow != null)
            {
                activeMap = Instantiate(activeMap, Vector3.zero, Quaternion.identity, tileMapGrid.transform);
                activeMapShadow = Instantiate(activeMapShadow, new Vector3(0, 0, 0.1f), Quaternion.identity, tileMapGrid.transform);
                pathsParent = Instantiate(pathsParent, new Vector3(0, 0, 0.1f), Quaternion.identity);
                spawnPoint = Instantiate(spawnPoint,spawnPoint.position,spawnPoint.rotation);
                targetPoint = Instantiate(targetPoint, targetPoint.position, targetPoint.rotation);
            }
        }
    }
}

