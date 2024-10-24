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

        //butonlarda interact with tower yok buyValue çekmenin başka yolunu bul
        for (int i = 0; i < towerSliderMenuContents.Count; i++)
        {
            if (towerSliderMenuContents[i].activeSelf)
            {
                if (towerSliderMenuContents[i].TryGetComponent<InteractWithTower>(out InteractWithTower interactWithTower))
                {
                    if (interactWithTower.buyValue <= Player.Instance.playerGold)
                    {
                        Debug.Log(1);
                        towerSliderMenuContents[i].GetComponent<Button>().image.color = Color.red;
                    }
                    else
                    {
                        Debug.Log(21);
                        towerSliderMenuContents[i].GetComponent<Button>().image.color = Color.white;
                    }
                }


            }

        }
    }
}
