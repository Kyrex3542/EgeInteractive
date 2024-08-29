using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private GameObject settingsMenu;

    public void Start()
    {
        settingsMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void UpdateGoldUI()
    {
       goldText.text= PlayerPrefs.GetInt(Player.GOLDPLAYERPREFS, 0).ToString();
      
    }
    public void OpenSettingsMenu()
    {
        Time.timeScale = 0.0f;
        settingsMenu.SetActive(true);

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
