using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class PlayerAttacker : MonoBehaviour
    {
        PlayerAnimatorManager animatorHandler;
        PlayerManager playerManager;
        PlayerStats playerStats;
        InputHandler inputHandler;
        public string lastAttack;

        [SerializeField]
        private string oh_heavy_attack_01;
        [SerializeField]
        private string oh_light_attack_01;
        [SerializeField]
        private string oh_light_attack_02;
        LayerMask backStabLayer = 1 << 12;
        LayerMask riposteLayer = 1 << 13;

        private void Awake()
        {
            animatorHandler = GetComponent<PlayerAnimatorManager>();
            playerManager = GetComponentInParent<PlayerManager>();
            playerStats = GetComponentInParent<PlayerStats>();
            inputHandler = GetComponentInParent<InputHandler>();
            animatorHandler = GetComponent<PlayerAnimatorManager>();
        }

        public void HandleWeaponCombo()
        {
            if (inputHandler.comboFlag)
            {
                animatorHandler.anim.SetBool("canDoCombo", false);

                if (lastAttack == oh_light_attack_01)
                {
                    animatorHandler.PlayTargetAnimation(oh_light_attack_02, true);
                }
            }
        }

        public void HandleLightAttack()
        {
            //animatorHandler.anim.SetBool("canMove", false);
            animatorHandler.PlayTargetAnimation(oh_light_attack_01, true);
            lastAttack = oh_light_attack_01;
        }

        public void HandleHeavyAttack()
        {
            //animatorHandler.anim.SetBool("canMove", false);
            animatorHandler.PlayTargetAnimation(oh_heavy_attack_01, true);
            lastAttack = oh_heavy_attack_01;
        }

        #region Input Actions
        public void HandleRBAction()
        {
            PerformRBMeleeAction();
        }
 
        #endregion

        #region Attack Actions
        private void PerformRBMeleeAction()
        {
            if (playerManager.canDoCombo)
            {
                inputHandler.comboFlag = true;
                HandleWeaponCombo();
                inputHandler.comboFlag = false;
            }
            else
            {
                if (playerManager.isInteracting)
                    return;

                if (playerManager.canDoCombo)
                    return;

                HandleLightAttack();
            }
        }
        #endregion

        #region Defense Actions
        private void PerformLBBlockAction()
        {
            if (playerManager.isInteracting)
                return;

            if (playerManager.isBlocking)
                return;

            animatorHandler.PlayTargetAnimation("Block Start", false, true);
            //playerEquipmentManager.OpenBlockingCollider();
            playerManager.isBlocking = true;
        }
        #endregion

    }
}