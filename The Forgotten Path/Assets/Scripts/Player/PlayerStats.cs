using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SG
{
    public class PlayerStats : CharacterStats
    {
        PlayerManager playerManager;

        HealthBar healthBar;
        PlayerAnimatorManager animatorHandler;

        private void Awake()
        {
            playerManager = GetComponent<PlayerManager>();

            healthBar = FindObjectOfType<HealthBar>();
            animatorHandler = GetComponentInChildren<PlayerAnimatorManager>();
        }

        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetCurrentHealth(currentHealth);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }


        public override void TakeDamage(int damage, string damageAnimation = "Damage_01")
        {
            if (playerManager.isInvulerable)
                return;

            base.TakeDamage(damage, damageAnimation = "Damage_01");
            healthBar.SetCurrentHealth(currentHealth);
            animatorHandler.PlayTargetAnimation(damageAnimation, true);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isDead = true;
                animatorHandler.PlayTargetAnimation("Dead_01", true);
                //HANDLE PLAYER DEATH
            }
        }

        public void TakeDamageNoAnimation(int damage)
        {
            currentHealth = currentHealth - damage;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isDead = true;
            }
        }


        public void HealPlayer(int healAmount)
        {
            currentHealth = currentHealth + healAmount;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            healthBar.SetCurrentHealth(currentHealth);
        }

        public void AddSouls(int souls)
        {
            soulCount = soulCount + souls;
        }

        //public static void RefreshInstance(ref PlayerStats player, PlayerStats Prefab)
        //{
        //    var position = new Vector3(0, -5, 0);
        //    var rotation = Quaternion.identity;
        //    if (player != null)
        //    {
        //        position = player.transform.position;
        //        rotation = player.transform.rotation;
        //        PhotonNetwork.Destroy(player.gameObject);
        //    }

        //    player = PhotonNetwork.Instantiate(Prefab.gameObject.name, position, rotation).GetComponent<PlayerStats>();
        //}

        //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        //{
        //    if (stream.IsWriting)
        //    {
        //        stream.SendNext(transform.position);
        //        stream.SendNext(transform.rotation);

        //    }
        //    else
        //    {
        //        transform.position = (Vector3)stream.ReceiveNext();
        //        transform.rotation = (Quaternion)stream.ReceiveNext();

        //    }
        //}
    }
}