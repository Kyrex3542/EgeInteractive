using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckTower : MonoBehaviour
{
    [SerializeField] private List<GameObject> towerSliderMenuContents;
    private void Start()
    {
        CheckAvaibleTowers();
    }
    private void CheckAvaibleTowers()
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
    public void CheckTowerPrices()
    {
       /* for (int i = 0; i < towerSliderMenuContents.Count; i++)
        {
            if (towerSliderMenuContents[i].activeSelf)
            {
                if (towerSliderMenuContents[i].GetComponent<InteractWithTower>().buyValue <= Player.Instance.playerGold)
                {
                    towerSliderMenuContents[i].GetComponent<Button>().image.color = Color.red;
                }
                else
                {
                    towerSliderMenuContents[i].GetComponent<Button>().image.color = Color.white;
                }
            }
            
        }*/
    }
}
