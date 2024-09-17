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


    [Header("Episode Settings")]
    public List<EpisodeSettings> EpisodeSettingList = new List<EpisodeSettings>();
    [System.Serializable]
    public class EpisodeSettings
    {
        [Header("Path Locations & Spawn Points")]
        public GameObject[] pathsParentList;
        public Transform[] spawnPoints;
        [Header("Map List")]
        [SerializeField] public List<Tilemap> tileMaps;
        [SerializeField] public List<Tilemap> tileMapShadows;
        [SerializeField] public List<Transform> targetPoints;
    }


    [Header("Dont Change")]
    [SerializeField] private GameObject tileMapGrid;
    [SerializeField] public int mapNumber = 0;
    [SerializeField] private GameObject[] pathsParent;


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
        if (mapNumber < episodeSettings.tileMaps.Count && mapNumber < episodeSettings.tileMapShadows.Count)
        {
            activeMap = episodeSettings.tileMaps[mapNumber];
            activeMapShadow = episodeSettings.tileMapShadows[mapNumber];
            pathsParent = episodeSettings.pathsParentList;
            spawnPoint = episodeSettings.spawnPoints;
            targetPoint = episodeSettings.targetPoints[mapNumber];
            if (activeMap != null && activeMapShadow != null)
            {
                activeMap = Instantiate(activeMap, Vector3.zero, Quaternion.identity, tileMapGrid.transform);
                activeMapShadow = Instantiate(activeMapShadow, new Vector3(0, 0, 0.1f), Quaternion.identity, tileMapGrid.transform);
                for (int i = 0; i < episodeSettings.pathsParentList.Length; i++)
                {
                    pathsParent[i] = Instantiate(pathsParent[i], new Vector3(0, 0, 0.1f), Quaternion.identity);
                    Instantiate(spawnPoint[i], spawnPoint[i].position, spawnPoint[i].rotation);
                }
                targetPoint = Instantiate(targetPoint, targetPoint.position, targetPoint.rotation);
            }
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

