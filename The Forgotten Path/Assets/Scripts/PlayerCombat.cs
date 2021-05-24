using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    private Animator VectorAnimator;
    [SerializeField]
    private Transform AttackSpot;
    [SerializeField]
    private float AttackRange;
    [SerializeField]
    private LayerMask EnemyLayer;
    [SerializeField]
    private Player Player;
    private float TimeBetweenAttack;
    private float StartTimeBetweenAttack;
    void Start()
    {

    }

    void Update()
    {

        if(TimeBetweenAttack<=0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
            }
            TimeBetweenAttack = StartTimeBetweenAttack;

        }
        else
        {
            TimeBetweenAttack -= Time.deltaTime;
        }
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    Attack();
        //}
    }

    private void Attack()
    {
        VectorAnimator.SetTrigger("Attack");

        Collider[] HitEnemies = Physics.OverlapSphere(AttackSpot.position, AttackRange, EnemyLayer);

        foreach (Collider enemy in HitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            GameObject Enemy = enemy.gameObject;
           
            if (Enemy.CompareTag("Enemy"))
            {
                Enemy.GetComponent<Enemy>().TakeDamage(Player.GetAttackDamage());
            }
            
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackSpot.position, AttackRange);
    }
}
