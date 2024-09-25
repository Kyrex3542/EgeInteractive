using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{

    [SerializeField] private Transform healthUIParent;
    [SerializeField] private GameObject healthUI;
    private List<GameObject> healthList = new List<GameObject>();
    public void SetMaxHealthUI(int healthAmount)
    {
         for (int i = 0; i < healthAmount; i++)
        {
           GameObject healt= Instantiate(healthUI,healthUIParent);
            healthList.Add(healt);
        }
    }
    public void UpdateHealthUI(int healthAmount)
    {
        foreach (GameObject health in healthList)
        {
            health.SetActive(false);
        }
        for (int i = 0;i < healthAmount&&i<healthList.Count; i++)
        {
            healthList[i].SetActive(true);
        }
    }
}
