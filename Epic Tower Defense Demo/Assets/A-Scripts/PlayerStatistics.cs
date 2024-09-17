using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    public int[] EnemyKilledCount;
    public int TotalCoinsEarned;
    public int TotalCoinsUsed;
    public int TotalWaveCountSurvived;
    public float TotalHoursPlayed;

    public void EnemyCount(int Index)
    {
        EnemyKilledCount[Index]++;
    }

    public void CoinEarned(int Value)
    {
        TotalCoinsEarned += Value;
    }

    public void CoinUsed(int Value)
    {
        TotalCoinsUsed += Value;
    }

    public void WaveSurvived()
    {
        TotalWaveCountSurvived++;
    }

    public void HourPlayed(float TimePlayed)
    {
        TotalHoursPlayed += TimePlayed;
    }
}

/*
 * "This area shows equal numbers of mob's. (Event Mobs not included)"
 * 0 = This will be empty but all Event Mobs kill count will collected here.
 * 1 = Mercenary
 * 2 = Mage
 * 3 = Knight
 * 4 = Fast Knight
 * 5 = Cavalry
 * 6 = Assassin
 * 7 = Armored Knight
 * 8 = King's Assistant
 * 9 = King
 * 10 = SupremeCommander
 * 11 = ProAssassin
 * 12 = MercenaryLeader
 * 13 = MageLeader
 * 14 = HonoredKnight
 * 15 = CavalaryBoss
 * 16 = CavalaryBossV2
 * 17 = Captain
 * 18 = AngryKnight
 * 19 = Villager
 */
