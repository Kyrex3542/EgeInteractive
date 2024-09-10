using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    #region Variables
    public GameObject MainMenu; public GameObject Play; public GameObject Envanter; public GameObject Ayarlar;
    public GameObject Market; public GameObject Madalyalar; public GameObject Credits; public GameObject Levels;
    public GameObject EventLevels; public GameObject Events; public AudioSource butonsesi; public GameObject currentmenu;
    #endregion
    #region Awake
    private void Awake()
    {currentmenu= MainMenu;}
    #endregion
    #region Scene Changer
    public void Mainmenu(){ currentmenu.SetActive(false); currentmenu = MainMenu; currentmenu.SetActive(true);}
    public void Playmenu(){ currentmenu.SetActive(false); currentmenu = Play; currentmenu.SetActive(true);}
    public void Envantermenu() { currentmenu.SetActive(false); currentmenu = Envanter; currentmenu.SetActive(true);}
    public void Ayarlarmenu() { currentmenu.SetActive(false); currentmenu = Ayarlar; currentmenu.SetActive(true);}
    public void Marketmenu() { currentmenu.SetActive(false); currentmenu = Market; currentmenu.SetActive(true);}
    public void Madalyalarmenu() { currentmenu.SetActive(false); currentmenu = Madalyalar; currentmenu.SetActive(true);}
    public void Creditsmenu() { currentmenu.SetActive(false); currentmenu = Credits; currentmenu.SetActive(true);}
    public void Eventsmenu() { currentmenu.SetActive(false); currentmenu = Events; currentmenu.SetActive(true);}
    public void Eventlevelsmenu() { currentmenu.SetActive(false); currentmenu = EventLevels; currentmenu.SetActive(true);}
    public void Levelsmenu() { currentmenu.SetActive(false); currentmenu = Levels; currentmenu.SetActive(true);}
    #endregion
    #region Map Loader
    public void LoadLevel(int mapNumber)
    {SceneManager.LoadScene("GamePlay"); PlayerPrefs.SetInt(Player.MAPNUMBERPLAYERPREFS, mapNumber); PlayerPrefs.Save();}
    #endregion
    #region Sound
    public void buttonSound()
    {butonsesi.Play();}
    #endregion
}