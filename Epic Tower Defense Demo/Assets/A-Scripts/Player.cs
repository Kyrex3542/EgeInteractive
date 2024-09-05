using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public static Player Instance { get; set; }
    public const string MAPNUMBERPLAYERPREFS = "MapNumber";
    public const string DIAMONDPLAYERPREFS = "Gold";
    [SerializeField] private UIManager manager;
    private int playerGold = 0;
    


    private void Awake()
    {
        Instance = this;   
    }
    
    public void GainGold(int amount)
    {
        playerGold += amount;
        manager.UpdateGoldUI(playerGold);
    }
    public void GainDiamond(int amount)
    {
        PlayerPrefs.SetInt(DIAMONDPLAYERPREFS, PlayerPrefs.GetInt(DIAMONDPLAYERPREFS,0)+amount);
        PlayerPrefs.Save();
    }
    public int GetPlayerCurrentGold()
    {
        return playerGold;
    }
    public void SpendGold(int amount)
    {
        playerGold -= amount;
        manager.UpdateGoldUI(playerGold);
    }
}
