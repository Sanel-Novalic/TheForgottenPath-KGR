using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int MaxHealth = 100;
    private int CurrentHealth;
    [SerializeField]
    private Animator EnemyAnimator;
    public event EventHandler OnHealthChanged;
    void Start()
    {
        CurrentHealth = MaxHealth;
        
    }
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
        if (CurrentHealth <= 0)
        {
            Die();
            Destroy(gameObject,5f);
        }
           
    }
    public float GetHealthPercent()
    {
        return (float)CurrentHealth / MaxHealth;
    }
    private void Die()
    {
        EnemyAnimator.SetTrigger("Died");
        
    }

    void Update()
    {

    }
}
