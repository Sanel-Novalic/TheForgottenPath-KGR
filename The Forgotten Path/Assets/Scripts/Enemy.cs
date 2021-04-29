using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int MaxHealth = 100;
    int CurrentHealth;
    void Start()
    {
        CurrentHealth = MaxHealth;
    }
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
    }
}
