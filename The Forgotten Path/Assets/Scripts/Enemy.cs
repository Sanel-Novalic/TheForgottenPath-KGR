using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int MaxHealth = 100;
    private int CurrentHealth;
    [SerializeField]
    private Animator EnemyAnimator;
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
        EnemyAnimator.SetTrigger("Died");
    }

    void Update()
    {

    }
}
