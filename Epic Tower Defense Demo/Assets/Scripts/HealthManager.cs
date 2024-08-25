using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image HealthBar;
    public float HealthAmount = 100f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(20);
        }
        if (HealthAmount <= 0)
            Destroy(transform.parent.gameObject);
    }

    void TakeDamage(float damage)
    {
        HealthAmount -= damage;
        HealthBar.fillAmount = HealthAmount / 100f;
    }
}
