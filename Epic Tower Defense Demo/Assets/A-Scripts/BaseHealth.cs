using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public int baseHealth = 100;
    HealthManager healthManager;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<HealthManager>();
        baseHealth -= Mathf.Abs((int)healthManager.HealthAmount);
       
    }
    private void Update()
    {
        print(baseHealth);
    }
}
