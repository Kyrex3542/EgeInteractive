using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerUnlocker : MonoBehaviour
{
    [SerializeField]private TowerGeneralData[] towerGeneralData;

    [SerializeField] private TextMeshProUGUI[] towerCostText;


    public void UnlockTower(int towerIndex)
    {
        if (towerGeneralData[towerIndex].towerPrice<=PlayerPrefs.GetInt(Player.DIAMONDPLAYERPREFS,0))
        {
            PlayerPrefs.SetInt(Player.DIAMONDPLAYERPREFS, PlayerPrefs.GetInt(Player.DIAMONDPLAYERPREFS, 0) - towerGeneralData[towerIndex].towerPrice);
            PlayerPrefs.SetInt("TowerIndex_" + towerIndex, 1);
            PlayerPrefs.Save();
            UpdateCostUI();
        }
        else
        {
            Debug.Log("Not enough Diamond");
        }
        
    }

    private void Start()
    {
        UpdateCostUI();
    }
    public void UpdateCostUI()
    {
        for (int i = 0; i < towerCostText.Length; i++)
        {
            towerCostText[i].text = towerGeneralData[i].towerPrice.ToString();
        }
    }
}
