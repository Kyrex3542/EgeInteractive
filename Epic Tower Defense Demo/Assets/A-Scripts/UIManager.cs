using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject interactionMenu;
    [SerializeField] private TextMeshProUGUI upgradeCost;
    [SerializeField] private TextMeshProUGUI sellValue;
    public void Start()
    {
        settingsMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void UpdateGoldUI()
    {
        goldText.text = PlayerPrefs.GetInt(Player.GOLDPLAYERPREFS, 0).ToString();

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
    public void Show_InteractionMenu(int upgradeCost, int sellValue)
    {
        this.upgradeCost.text = "Upgrade: " + upgradeCost.ToString();
        this.sellValue.text = "Sell: " + sellValue.ToString();
        interactionMenu.SetActive(true);
    }
    public void Hide_InteractionMenu()
    {
        interactionMenu.SetActive(false);
    }
}
