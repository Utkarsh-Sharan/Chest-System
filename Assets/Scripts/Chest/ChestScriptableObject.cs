using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestScriptableObject", menuName = "ScriptableObjects/ChestScriptableObject")]
public class ChestScriptableObject : ScriptableObject
{
    [Header("Chest Properties")]
    public ChestType ChestType;
    public Sprite ChestImage;

    [Header("Rewards")]
    public RangeInt CoinRange;
    public RangeInt GemRange;

    [Header("Unlocking Time")]
    public int UnlockTime;
}

[System.Serializable]
public struct RangeInt
{
    public int Min;
    public int Max;

    public RangeInt(int min, int max)
    {
        Min = min;
        Max = max;
    }

    /// <summary>
    /// Get a random value within the range.
    /// </summary>
    public int GetRandomValue() => Random.Range(Min, Max + 1);
}