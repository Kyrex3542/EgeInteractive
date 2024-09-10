using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Play;
    public GameObject Envanter;
    public GameObject Ayarlar;
    public GameObject Market;
    public GameObject Madalyalar;
    public GameObject Credits;
    public GameObject EventLevels;
    public GameObject Levels;
    public GameObject activescene;
    public GameObject Events;
    public AudioSource butonsesi;
    private void Awake()
    {
        activescene = MainMenu.gameObject;
        activescene.gameObject.SetActive(true);
    }
    public void LevelsMenu()
    {
        activescene.SetActive(false);
        activescene = Levels;
        activescene.SetActive(true);
    }
    public void eventsmenu()
    {
        activescene.SetActive(false);
        activescene = Events;
        activescene.SetActive(true);
    }
    public void eventlevelsmenu()
    {
        activescene.SetActive(false);
        activescene = EventLevels;
        activescene.SetActive(true);
    }
    public void Mainmenu()
    {
        activescene.SetActive(false);
       activescene = MainMenu;
        activescene.SetActive(true);
    }
    public void Playmenu()
    {
        activescene.SetActive(false);
        activescene = Play;
        activescene.SetActive(true);
    }
    public void Envantermenu()
    {
        activescene.SetActive(false);
        activescene = Envanter;
        activescene.SetActive(true);
    }
    public void Ayarlarmenu()
    {
        activescene.SetActive(false);
        activescene = Ayarlar;
        activescene.SetActive(true);
    }
    public void Marketmenu()
    {
        activescene.SetActive(false);
        activescene = Market;
        activescene.SetActive(true);
    }
    public void Madalyalarmenu()
    {
        activescene.SetActive(false);
        activescene = Madalyalar;
        activescene.SetActive(true);
    }
    public void Creditsmenu()
    {
        activescene.SetActive(false);
        activescene = Credits;
        activescene.SetActive(true);
    }
    

    public void LoadLevel(int mapNumber)
    {
        SceneManager.LoadScene("GamePlay");
        PlayerPrefs.SetInt(Player.MAPNUMBERPLAYERPREFS, mapNumber);
        PlayerPrefs.Save();
    }

    
    public void buttonSound()
    {
        butonsesi.Play();
    }
}
