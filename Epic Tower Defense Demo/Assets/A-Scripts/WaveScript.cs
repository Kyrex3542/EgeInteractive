using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaveScript : MonoBehaviour
{
    [SerializeField] private MapLoader mapLoader;

    private int WaveCounter = 1;
    private int MobCounter = 0;
    private float SpawnTimer;
    private int MobCountHolder;
    private int MapNumber;
    private float SmootherOfSpawn = 0.6f;
    public SpawnerScript SpawnerScriptCaller;

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

    [Header("Episode Settings")]
    public List<EpisodeNumber> EpisodesSettings = new List<EpisodeNumber>();
    [System.Serializable]
    public class EpisodeNumber
    {
        public List<WaveSettings> WaveSettingsList = new List<WaveSettings>();
    }

    void Start()
    {
        SpawnerScriptCaller = GetComponent<SpawnerScript>();
        mapLoader = FindFirstObjectByType<MapLoader>();
        MapNumber = mapLoader.GetMapNumber();
    }

    public void Update()
    {
        if (WaveCounter <= EpisodesSettings[MapNumber].WaveSettingsList.Count)
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
        WaveSettings CurrentWave = EpisodesSettings[MapNumber].WaveSettingsList[WaveCounter - 1];
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
            SmootherOfSpawn -= Time.deltaTime;
            if (waveSettings.EnemyPrefabs[i] != null && waveSettings.NumberOfMobs[i] > 0 && waveSettings.FirstAppearNumberOfEnemy[i] <= MobCounter && SmootherOfSpawn <= 0)
            {
                waveSettings.SpawnDelayTimes[i] -= Time.deltaTime;
                if (waveSettings.SpawnDelayTimes[i] <= 0)
                {
                    MobCountHolder = SpawnerScriptCaller.Spawner(waveSettings.EnemyPrefabs[i]);
                    MobCounter += MobCountHolder;
                    waveSettings.NumberOfMobs[i] -= MobCountHolder;
                    waveSettings.SpawnDelayTimes[i] = waveSettings.SpawnRateTimes[i];
                    SmootherOfSpawn = 0.6f;
                }
            }
        }
    }
}
