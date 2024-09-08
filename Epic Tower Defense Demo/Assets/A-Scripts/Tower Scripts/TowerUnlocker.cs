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
        
        PlayerPrefs.SetInt(Player.DIAMONDPLAYERPREFS, PlayerPrefs.GetInt(Player.DIAMONDPLAYERPREFS, 0) - towerGeneralData[towerIndex].towerPrice);
        PlayerPrefs.SetInt("TowerIndex_" + towerIndex, 1);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        for (int i = 0; i < towerCostText.Length; i++) 
        {
            towerCostText[i].text = towerGeneralData[i].towerPrice.ToString();
        }
    }
}
