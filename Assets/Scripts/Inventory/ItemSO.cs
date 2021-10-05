using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatModifier
{
    HealthBuff,
    StrengthBuff,
    DefenseBuff
}

[CreateAssetMenu(fileName = "Items", menuName = "Create New Item")]
public class ItemSO : ScriptableObject
{
    public string ItemName;
    public Sprite Icon;
    public string Description;
    public StatModifier Stat;
    public float Value;
    public GameObject prefab;
}
