using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLoader : MonoBehaviour
{
    public Tilemap activeMap;
    public Tilemap activeMapShadow;
    [SerializeField] private List<Tilemap> tileMaps;
    [SerializeField] private List<Tilemap> tileMapShadows;
    [SerializeField] private GameObject tileMapGrid;
    [SerializeField] private int mapNumber = 0;
    private void Awake()
    {

        if (mapNumber < tileMaps.Count && mapNumber < tileMapShadows.Count)
        {
            activeMap = tileMaps[mapNumber];
            activeMapShadow = tileMapShadows[mapNumber];

            if (activeMap != null && activeMapShadow != null)
            {
                activeMap = Instantiate(activeMap, Vector3.zero, Quaternion.identity, tileMapGrid.transform);
                activeMapShadow = Instantiate(activeMapShadow, new Vector3(0, 0, 0.1f), Quaternion.identity, tileMapGrid.transform);
            }         
        }
        

    }
}
