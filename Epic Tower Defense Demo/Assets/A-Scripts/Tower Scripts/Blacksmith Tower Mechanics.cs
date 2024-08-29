using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithTowerMechanics : MonoBehaviour
{

    [Header("Properties")]
    [SerializeField] private int moneyAmount=5;
    [SerializeField, Tooltip("Make Money Per Second")] private float makeMoneyRate;

    private float makeMoneyRateTimerMax;
    private float makeMoneyRateTimer = 0;
    private void Start()
    {
        makeMoneyRateTimerMax = 1 / makeMoneyRate;
    }
    private void Update()
    {
        makeMoneyRateTimer -= Time.deltaTime;
        if (makeMoneyRateTimer < 0) 
        {
            MakeMoney();
            makeMoneyRateTimer = makeMoneyRateTimerMax;
        }
    }

    private void MakeMoney()
    {
       Player.Instance.GainGold(moneyAmount);
    }
    
}
