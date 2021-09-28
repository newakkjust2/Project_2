using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private string characterName;

    public float Health
    {
        get;
        private set;
    }
    private float defense;
    private float speed;
    private float attack;

    public void LoadStats()
    {
        Health = PlayerPrefs.GetFloat("Health", 100f);
        defense = PlayerPrefs.GetFloat("Defense", 50f);
        attack = PlayerPrefs.GetFloat("Attack", 50f);
        speed = PlayerPrefs.GetFloat("Speed", 50f);
    }

    public void SaveStats(float health, float defense, float attack, float speed)
    {
        PlayerPrefs.SetFloat("Health", health);
    }
}
