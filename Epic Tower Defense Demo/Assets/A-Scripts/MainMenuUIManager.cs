using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private TowerUnlocker towerUnlocker;

    [SerializeField] private TextMeshProUGUI playerDiamond;


    private void Start()
    {
        UpdateMainMenuUI();
    }
    private void UpdateMainMenuUI()
    {
        playerDiamond.text = PlayerPrefs.GetInt(Player.DIAMONDPLAYERPREFS, 0).ToString();
       towerUnlocker.UpdateCostUI();
    }
}
