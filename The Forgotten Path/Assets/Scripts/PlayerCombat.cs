using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform AttackPoint;
    [SerializeField]
    private float AttackRange = 0.5f;
    [SerializeField]
    private LayerMask EnemyLayers;
    private void Attack()
    {
        animator.SetTrigger("Attack");

        Collider[] HitEnemies = Physics.OverlapSphere(AttackPoint.position, AttackRange, EnemyLayers);
        foreach (Collider Enemy in HitEnemies)
            Debug.Log("We hit" + Enemy.name);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Attack();
        }
    }
}
