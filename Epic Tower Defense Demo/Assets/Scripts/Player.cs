using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public static Player Instance { get; set; }
    public const string MAPNUMBERPLAYERPREFS = "MapNumber";
    public const string GOLDPLAYERPREFS = "Gold";
    [SerializeField] private UIManager manager;
    


    private void Awake()
    {
        Instance = this;
    }
    
    public void GainGold(int amount)
    {
        PlayerPrefs.SetInt(GOLDPLAYERPREFS, PlayerPrefs.GetInt(GOLDPLAYERPREFS,0)+amount);
        PlayerPrefs.Save();
        manager.UpdateGoldUI();
    }
}
