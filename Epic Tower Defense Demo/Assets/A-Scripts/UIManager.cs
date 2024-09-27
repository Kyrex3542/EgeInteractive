using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject interactionMenu;
    [SerializeField] private TextMeshProUGUI upgradeCost;
    [SerializeField] private TextMeshProUGUI sellValue;
    public Button upgradeBtn;
    [Header("End Panel")]
    [SerializeField] private GameObject endPanel;
    [SerializeField] private TextMeshProUGUI winOrLoseText;
    [SerializeField] private TextMeshProUGUI killCount;
    [SerializeField] private TextMeshProUGUI goldGain;
    [SerializeField] private TextMeshProUGUI diamondGain;
    [SerializeField] private Button loadNextLevelBtn;//Bölüm kazanılmadığın disable edebilmek için

    public void Start()
    {
        settingsMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void UpdateGoldUI(int goldAmount)
    {
        goldText.text = goldAmount.ToString();

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
    public void UpdateEndPanelTexts(bool playerWon)
    {
        
        if(playerWon)
        {
            winOrLoseText.text = "You have Won \nCongrats";
            winOrLoseText.color = Color.green;
        }
        else
        {
            winOrLoseText.text = "You lose. \nKEEP TRYING";
            winOrLoseText.color = Color.red;
        }
        killCount.text = "You have killed " + Player.Instance.playerkillCountStatistic + " Enemies!";
        goldGain.text = "You have gained " + Player.Instance.playerGoldStatistic + " Gold!";
        diamondGain.text = "You have killed " + 5 + " Enemies!";
    }
    public void Show_EndPanel(bool playerWon)
    {
        endPanel.SetActive(true);
        UpdateEndPanelTexts(playerWon);
    }
    public void Hide_EndPanel()
    {
        endPanel.SetActive(true);

    }
    public void LoadNextLevel()
    {
        int mapNumber = PlayerPrefs.GetInt(Player.MAPNUMBERPLAYERPREFS, 0);
        mapNumber++;
        SceneManager.LoadScene("GamePlay");
        PlayerPrefs.SetInt(Player.MAPNUMBERPLAYERPREFS, mapNumber);
        PlayerPrefs.Save();
    }
}
