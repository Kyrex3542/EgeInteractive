using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointScript : MonoBehaviour
{
    public int baseHealth;
    public HealthUI healthUI;
    public void SetHealthUI()
    {
        healthUI.SetMaxHealthUI(baseHealth);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            baseHealth -= 1;
            healthUI.UpdateHealthUI(baseHealth);
            if (baseHealth <= 0)
            {
                Time.timeScale = 0;
            }
        }
    }
}
