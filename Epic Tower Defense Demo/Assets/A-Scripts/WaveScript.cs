using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaveScript : MonoBehaviour
{
    private int WaveCounter = 1;
    private int MobCounter = 0;
    private float SpawnTimer;
    public SpawnerScript SpawnerScriptCaller;

    [Header("Wave Settings")]
    public List<WaveSettings> WaveSettingsList = new List<WaveSettings>();
    [System.Serializable]
    public class WaveSettings
    {
        public int WaveNumber;
        [Header("Enemy Settings")]
        public int TotalEnemyNumber;
        public GameObject[] EnemyPrefabs;
        public int[] NumberOfMobs;
        public int[] FirstAppearNumberOfEnemy;
        public float[] SpawnRateTimes;
        public float[] SpawnDelayTimes;
    }

    void Start()
    {
        SpawnerScriptCaller = GetComponent<SpawnerScript>();
    }

    public void Update()
    {
        if (WaveCounter <= WaveSettingsList.Count)
        {
            WaveCaller();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void WaveCaller()
    {
        WaveSettings CurrentWave = WaveSettingsList[WaveCounter - 1];
        if (CurrentWave.TotalEnemyNumber > MobCounter)
        {
            MobIsAvaiable(CurrentWave);
        }
        else
        {
            WaveCounter++;
            MobCounter = 0;
        }
    }

    private void MobIsAvaiable(WaveSettings waveSettings)
    {
        int numEnemyTypes = waveSettings.EnemyPrefabs.Length;

        for (int i = 0; i < numEnemyTypes; i++)
        {
            if (waveSettings.EnemyPrefabs[i] != null && waveSettings.NumberOfMobs[i] > 0 && waveSettings.FirstAppearNumberOfEnemy[i] <= MobCounter)
            {
                waveSettings.SpawnDelayTimes[i] -= Time.deltaTime;
                if (waveSettings.SpawnDelayTimes[i] <= 0)
                {
                    MobCounter++;
                    SpawnerScriptCaller.Spawner(waveSettings.EnemyPrefabs[i]);
                    waveSettings.NumberOfMobs[i]--;
                    waveSettings.SpawnDelayTimes[i] = waveSettings.SpawnRateTimes[i];
                }
            }
        }
    }
}
