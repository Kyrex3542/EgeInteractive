using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLoader : MonoBehaviour
{
    [Header("Maps")]
    public Tilemap activeMap;
    public Tilemap activeMapShadow;
    [SerializeField] private List<Tilemap> tileMaps;
    [SerializeField] private List<Tilemap> tileMapShadows;
    [SerializeField] private GameObject tileMapGrid;
    [SerializeField] private int mapNumber = 0;
    [SerializeField] private List<GameObject> pathsParentList;
    [SerializeField] private GameObject pathsParent;
    private void Awake()
    {

        if (mapNumber < tileMaps.Count && mapNumber < tileMapShadows.Count)
        {
            activeMap = tileMaps[mapNumber];
            activeMapShadow = tileMapShadows[mapNumber];
            pathsParent = pathsParentList[mapNumber];
            if (activeMap != null && activeMapShadow != null)
            {
                activeMap = Instantiate(activeMap, Vector3.zero, Quaternion.identity, tileMapGrid.transform);
                activeMapShadow = Instantiate(activeMapShadow, new Vector3(0, 0, 0.1f), Quaternion.identity, tileMapGrid.transform);
                pathsParent = Instantiate(pathsParent, new Vector3(0, 0, 0.1f), Quaternion.identity);
            }         
        }
    }
    public GameObject GetPathsParent()
    {

        return pathsParent;
    }
}

