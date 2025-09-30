using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int level;
    public int healthLevel;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth;


    Animator animatorHandler;

    void Awake()
    {
        animatorHandler = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
    }

    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        animatorHandler.Play("Damage_01");

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            animatorHandler.Play("Dead_01");
            
            //Handle Enemy Death
        }
    }
}
