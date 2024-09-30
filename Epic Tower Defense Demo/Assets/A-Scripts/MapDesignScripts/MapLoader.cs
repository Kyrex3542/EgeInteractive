using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLoader : MonoBehaviour
{
    [Header("Health System")]
    [SerializeField]private HealthUI healthUI;
    [SerializeField]private UIManager UImanager;
    [SerializeField] private int baseHealth;
    [Header("Active Map")]
    public Tilemap activeMap;
    public Tilemap activeMapShadow;
    public Transform[] spawnPoint;
    public Transform targetPoint;


    [Header("Episode Settings")]
    public List<EpisodeSettings> EpisodeSettingList = new List<EpisodeSettings>();
    [System.Serializable]
    public class EpisodeSettings
    {
        [Header("Path Locations & Spawn Points")]
        public GameObject[] pathsParentList;
        public Transform[] spawnPoints;
        public GameObject[] obstacleSpawnPointsParentList;
        [Header("Map List")]
        [SerializeField] public List<Tilemap> tileMaps;
        [SerializeField] public List<Tilemap> tileMapShadows;
        [SerializeField] public List<Transform> targetPoints;
    }


    [Header("Dont Change")]
    [SerializeField] private GameObject tileMapGrid;
    [SerializeField] public int mapNumber = 0;
    [SerializeField] private GameObject[] pathsParent;
    [SerializeField] private GameObject obstacleSpawnPointsParent;


    private void Awake()
    {
        mapNumber = PlayerPrefs.GetInt(Player.MAPNUMBERPLAYERPREFS, 0);
        SetMapVariables();
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
        EpisodeSettings episodeSettings = EpisodeSettingList[mapNumber];
        
            activeMap = episodeSettings.tileMaps[0];
            activeMapShadow = episodeSettings.tileMapShadows[0];
            pathsParent = episodeSettings.pathsParentList;
            spawnPoint = episodeSettings.spawnPoints;
            obstacleSpawnPointsParent = episodeSettings.obstacleSpawnPointsParentList[0];
            targetPoint = episodeSettings.targetPoints[0];
            if (activeMap != null && activeMapShadow != null)
            {
                activeMap = Instantiate(activeMap, Vector3.zero, Quaternion.identity, tileMapGrid.transform);
                activeMapShadow = Instantiate(activeMapShadow, new Vector3(0, 0, 0.1f), Quaternion.identity, tileMapGrid.transform);
                for (int i = 0; i < episodeSettings.pathsParentList.Length; i++)
                {
                    pathsParent[i] = Instantiate(pathsParent[i], new Vector3(0, 0, 0.1f), Quaternion.identity);
                    Instantiate(spawnPoint[i], spawnPoint[i].position, spawnPoint[i].rotation);
                }
                for(int i = 0; i < obstacleSpawnPointsParent.transform.childCount; i++)
                {
                    Instantiate(obstacleSpawnPointsParent.transform.GetChild(i), obstacleSpawnPointsParent.transform.GetChild(i).position, Quaternion.identity);
                }
                targetPoint = Instantiate(targetPoint, targetPoint.position, targetPoint.rotation);
                if(targetPoint.TryGetComponent<EndPointScript>(out EndPointScript endPointScript))
                {
                    endPointScript.baseHealth = baseHealth;
                    endPointScript.healthUI = healthUI;
                    endPointScript.UImanager = UImanager;
                    endPointScript.SetHealthUI();
                }
                else { Debug.LogError("EndPointScript bulunamadı"); }
            }
        
    }

    public GameObject[] GetPathsParent()
    {
        return pathsParent;
    }
    public Transform[] GetSpawnLocs()
    {
        return spawnPoint;
    }

    public int GetMapNumber()
    {
        return mapNumber;
    }
}

