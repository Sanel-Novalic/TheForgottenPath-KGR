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
    private float AttackDelay ;
    private float LastAttacked;
    private AnimatorStateInfo AnimInfo;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
           
                Attack();
             
        }
    }

    private void Attack()
    {

    while(Time.time > LastAttacked + AttackDelay && Player.CurrentHealth > 0)
    {
            VectorAnimator.SetTrigger("Attack");
        AttackDelay = VectorAnimator.GetCurrentAnimatorStateInfo(0).length;
        Collider[] HitEnemies = Physics.OverlapSphere(AttackSpot.position, AttackRange, EnemyLayer);

            foreach (Collider enemy in HitEnemies)
            {
                Debug.Log("We hit " + enemy.name);
                GameObject Enemy = enemy.gameObject;

                if (Enemy.CompareTag("Enemy"))
                {
                    Enemy.GetComponent<Enemy>().TakeDamage(50);
                }

            }
            LastAttacked = Time.time;
        }

        VectorAnimator.SetTrigger("Attack");
        AttackDelay = VectorAnimator.GetCurrentAnimatorStateInfo(0).length;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackSpot.position, AttackRange);
    }
}
