using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTower : MonoBehaviour
{
    [SerializeField] private List<GameObject> towerSliderMenuContents;
    private void Start()
    {
        for (int i = 0; i < towerSliderMenuContents.Count; i++)
        {
            GameObject obj = towerSliderMenuContents[i];
            if (PlayerPrefs.GetInt("TowerIndex_" + i) == 1)
            {
                obj.SetActive(true);
            }
            else
            {
                obj.SetActive(false);
            }
        }
    }
}
