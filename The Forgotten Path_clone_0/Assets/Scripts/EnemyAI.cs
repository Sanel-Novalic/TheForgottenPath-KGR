using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class EnemyAI : MonoBehaviour
    {


        private GameObject Player;
        [SerializeField]
        private int AttackDamage = 60;
        [SerializeField]
        float TargetRange = 30f;
        [SerializeField]
        private float Speed;
        private Animator AnimatorEnemy;
        [SerializeField]
        private Transform AttackSpot;
        [SerializeField]
        private float AttackRange;
        [SerializeField]
        private LayerMask PlayerLayer;
        private float AttackTime;
        private float LastAttacked;
        private float AttackDelay = 3f;
        private EnemyStats Enemy;
        private void Start()
        {

            AnimatorEnemy = this.GetComponentInChildren<Animator>();
            Player = GameObject.FindWithTag("Player");
            Enemy = this.GetComponent<EnemyStats>();

        }
        private void Update()
        {
            transform.LookAt(Player.transform);
            if (Vector3.Distance(transform.position, Player.transform.position) <= TargetRange && Vector3.Distance(transform.position, Player.transform.position) > AttackRange)
            {
                transform.position += transform.forward * Speed * Time.deltaTime;

                AnimatorEnemy.SetTrigger("Walk");





            }
            else if (Vector3.Distance(transform.position, Player.transform.position) <= AttackRange)
            {



                Attack();

            }
            else
                AnimatorEnemy.SetTrigger("Idle");


        }

        private void Attack()
        {
            AnimatorEnemy.SetTrigger("Attack");

            AttackDelay = AnimatorEnemy.GetCurrentAnimatorStateInfo(0).length;

            while (Time.time > LastAttacked + AttackDelay && Enemy.currentHealth > 0)
            {

                Collider[] HitPlayers = Physics.OverlapSphere(AttackSpot.position, AttackRange, PlayerLayer);

                foreach (Collider player in HitPlayers)
                {
                    Debug.Log("Hit " + player.name);

                    Player.GetComponent<PlayerStats>().TakeDamage(AttackDamage);

                }
                LastAttacked = Time.time;
            }


        }
        //private void OnDrawGizmosSelected()
        //{
        //    Gizmos.DrawWireSphere(AttackSpot.position, AttackRange);
        //}
        public void GetClipTime()
        {
            AnimationClip[] Clips = AnimatorEnemy.runtimeAnimatorController.animationClips;
            foreach (AnimationClip clip in Clips)
            {
                if (clip.name == "Attack")
                    AttackTime = clip.length;
            }
        }
    }
}