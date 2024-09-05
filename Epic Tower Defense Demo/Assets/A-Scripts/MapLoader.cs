using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLoader : MonoBehaviour
{
    [Header("Active Map")]
    public Tilemap activeMap;
    public Tilemap activeMapShadow;
    public Transform[] spawnPoint;
    public Transform targetPoint;
    [Header("Path Locations & Spawn Point")]
    public List<PathLocations> PathLocationList = new List<PathLocations>();
    [System.Serializable]
    public class PathLocations
    {
        public GameObject[] pathsParentList;
        public Transform[] spawnPoints;
    }
    [Header("Map List")]
    [SerializeField] private List<Tilemap> tileMaps;
    [SerializeField] private List<Tilemap> tileMapShadows;
    [SerializeField] private List<Transform> targetPoints;
    [Header("Dont Change")]
    [SerializeField] private GameObject tileMapGrid;
    [SerializeField] private int mapNumber = 0;
    [SerializeField] private GameObject[] pathsParent;
    private void Awake()
    {
        mapNumber = PlayerPrefs.GetInt(Player.MAPNUMBERPLAYERPREFS, 0);
        SetMapVariables();
    }
    public GameObject[] GetPathsParent()
    {
        return pathsParent;
    }
    public Transform[] GetSpawnLocs()
    {
        return spawnPoint;
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
        PathLocations pathLocations = PathLocationList[mapNumber];
        if (mapNumber < tileMaps.Count && mapNumber < tileMapShadows.Count)
        {
            activeMap = tileMaps[mapNumber];
            activeMapShadow = tileMapShadows[mapNumber];
            pathsParent = pathLocations.pathsParentList;
            spawnPoint = pathLocations.spawnPoints;
            targetPoint = targetPoints[mapNumber];
            if (activeMap != null && activeMapShadow != null)
            {
                activeMap = Instantiate(activeMap, Vector3.zero, Quaternion.identity, tileMapGrid.transform);
                activeMapShadow = Instantiate(activeMapShadow, new Vector3(0, 0, 0.1f), Quaternion.identity, tileMapGrid.transform);
                for (int i = 0; i < pathLocations.pathsParentList.Length; i++)
                {
                    pathsParent[i] = Instantiate(pathsParent[i], new Vector3(0, 0, 0.1f), Quaternion.identity);
                    Instantiate(spawnPoint[i], spawnPoint[i].position, spawnPoint[i].rotation);
                }
                targetPoint = Instantiate(targetPoint, targetPoint.position, targetPoint.rotation);
            }
        }
    }
}

