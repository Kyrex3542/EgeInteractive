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
    public AudioSource butonsesi;

    public void Mainmenu()
    {
        MainMenu.SetActive(true);
        Play.SetActive(false);
        Envanter.SetActive(false);
        Ayarlar.SetActive(false);
        Market.SetActive(false);
        Madalyalar.SetActive(false);
        Credits.SetActive(false);
    }
    public void Playmenu()
    {
        MainMenu.SetActive(false);
        Play.SetActive(true);
        Envanter.SetActive(false);
        Ayarlar.SetActive(false);
        Market.SetActive(false);
        Madalyalar.SetActive(false);
        Credits.SetActive(false);
    }
    public void Envantermenu()
    {
        MainMenu.SetActive(false);
        Play.SetActive(false);
        Envanter.SetActive(true);
        Ayarlar.SetActive(false);
        Market.SetActive(false);
        Madalyalar.SetActive(false);
        Credits.SetActive(false);
    }
    public void Ayarlarmenu()
    {
        MainMenu.SetActive(false);
        Play.SetActive(false);
        Envanter.SetActive(false);
        Ayarlar.SetActive(true);
        Market.SetActive(false);
        Madalyalar.SetActive(false);
        Credits.SetActive(false);
    }
    public void Marketmenu()
    {
        MainMenu.SetActive(false);
        Play.SetActive(false);
        Envanter.SetActive(false);
        Ayarlar.SetActive(false);
        Market.SetActive(true);
        Madalyalar.SetActive(false);
        Credits.SetActive(false);
    }
    public void Madalyalarmenu()
    {
        MainMenu.SetActive(false);
        Play.SetActive(false);
        Envanter.SetActive(false);
        Ayarlar.SetActive(false);
        Market.SetActive(false);
        Madalyalar.SetActive(true);
        Credits.SetActive(false);
    }
    public void Creditsmenu()
    {
        MainMenu.SetActive(false);
        Play.SetActive(false);
        Envanter.SetActive(false);
        Ayarlar.SetActive(false);
        Market.SetActive(false);
        Madalyalar.SetActive(false);
        Credits.SetActive(true);
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("GamePlay");
        Player.Instance.mapNumber = 0;
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene("GamePlay");
        Player.Instance.mapNumber = 1;
    }
    public void LevelThree()
    {
        SceneManager.LoadScene("GamePlay");
        Player.Instance.mapNumber = 2;
    }
    public void buttonSound()
    {
        butonsesi.Play();
    }
}
