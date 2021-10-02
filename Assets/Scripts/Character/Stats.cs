using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    private string characterName;
    public float Health
    {
        get;
        private set;
    }
    private float attack;
    private float defense;
    private float speed;
    private float exp;
    [SerializeField] private float maxAttackSlider, maxDefenseSlider, maxSpeedSlider, maxEXPSlider = 1f;
    [SerializeField] private Slider attackSlider, defenseSlider, speedSlider, EXPSlider;

    private void Start()
    {
        attack = PlayerPrefs.GetFloat("Player_Attack", -1);
        if (attack == -1f)
        {
            InitialStats();
        }
        else
        {
            LoadStats();
        }

    }
    
    
    void InitialStats()
    {
        attackSlider.value = .1f;
        defenseSlider.value = .1f;
        speedSlider.value = .1f;
        EXPSlider.value = 0f;
    }
    
    public void LoadStats()
    {
        Health = PlayerPrefs.GetFloat("Health", 100f);
        defense = PlayerPrefs.GetFloat("Defense", 50f);
        attack = PlayerPrefs.GetFloat("Attack", 50f);
        speed = PlayerPrefs.GetFloat("Speed", 50f);
        exp = PlayerPrefs.GetFloat("Player_EXP", 0);
    }

    public static void SaveStats(float health, float defense, float attack, float speed, float EXP)
    {
        PlayerPrefs.SetFloat("Player_Health", health);
        PlayerPrefs.SetFloat("Player_Attack", attack);
        PlayerPrefs.SetFloat("Player_Defense", defense);
        PlayerPrefs.SetFloat("Player_Speed", speed);
        PlayerPrefs.SetFloat("Player_EXP", EXP);
    }
}
