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
    private Enemy Enemy;
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
        VectorAnimator.SetTrigger("Attack");

        Collider[] HitEnemies = Physics.OverlapSphere(AttackSpot.position, AttackRange, EnemyLayer);

        foreach (Collider Enemy in HitEnemies)
        {
            Debug.Log("We hit " + Enemy.name);
        }
        Enemy.TakeDamage(100);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackSpot.position, AttackRange);
    }
}
