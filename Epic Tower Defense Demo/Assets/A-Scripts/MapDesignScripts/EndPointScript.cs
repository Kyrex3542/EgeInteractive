using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointScript : MonoBehaviour
{
    private int BaseHealth;
    private void Start()
    {
        BaseHealth = 10;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            BaseHealth -= 1;
            if (BaseHealth <= 0)
            {
                Time.timeScale = 0;
            }
        }
    }
    
}
