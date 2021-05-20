using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int XP = 20;
    [SerializeField]
    private int MaxHealth = 100;
    [HideInInspector]
    public int CurrentHealth;
    [SerializeField]
    private Animator EnemyAnimator;
    public event EventHandler OnHealthChanged;
    private GameObject Player;
    void Start()
    {
        CurrentHealth = MaxHealth;
        Player = GameObject.FindWithTag("Player");
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
        Player.GetComponent<LevelSystem>().IncreaseXP(XP);
        
    }

    void Update()
    {

    }
}
