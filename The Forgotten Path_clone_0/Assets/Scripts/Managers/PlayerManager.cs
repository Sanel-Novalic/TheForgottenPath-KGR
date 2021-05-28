using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class PlayerManager : CharacterManager
    {
        InputHandler inputHandler;
        Animator anim;
        CameraHandler cameraHandler;
        PlayerStats playerStats;
        PlayerAnimatorManager playerAnimatorManager;
        PlayerLocomotion playerLocomotion;
        public GameObject LocalPlayerInstance;
        public GameObject interactableUIGameObject;
        public GameObject itemInteractableGameObject;

        public bool isInteracting;
        public bool canMove;
        [Header("Player Flags")]
        public bool isSprinting;
        public bool isInAir;
        public bool isGrounded;
        public bool canDoCombo;
        public bool isUsingRightHand;
        public bool isUsingLeftHand;
        public bool isInvulerable;

        private void Awake()
        {
            if (photonView.IsMine)
                LocalPlayerInstance = this.gameObject;
            cameraHandler = FindObjectOfType<CameraHandler>();
            //backStabCollider = GetComponentInChildren<CriticalDamageCollider>();
            inputHandler = GetComponent<InputHandler>();
            playerAnimatorManager = GetComponentInChildren<PlayerAnimatorManager>();
            anim = GetComponentInChildren<Animator>();
            playerStats = GetComponent<PlayerStats>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
            DontDestroyOnLoad(gameObject);
        }


        void Update()
        {
            float delta = Time.deltaTime;

            isInteracting = anim.GetBool("isInteracting");
            canDoCombo = anim.GetBool("canDoCombo");
            //isUsingRightHand = anim.GetBool("isUsingRightHand");
            //isUsingLeftHand = anim.GetBool("isUsingLeftHand");
            //isInvulerable = anim.GetBool("isInvulnerable");
            //isFiringSpell = anim.GetBool("isFiringSpell");
            //anim.SetBool("isInAir", isInAir);
            ////anim.SetBool("isDead", playerStats.isDead);
            //anim.SetBool("isBlocking", isBlocking);

            inputHandler.TickInput(delta);
            playerAnimatorManager.canRotate = anim.GetBool("canRotate");
            playerLocomotion.HandleRollingAndSprinting(delta);
            playerLocomotion.HandleJumping();

        }

        private void FixedUpdate()
        {
            float delta = Time.fixedDeltaTime;

            //playerLocomotion.HandleFalling(delta, playerLocomotion.moveDirection);
            playerLocomotion.HandleMovement(delta);
            playerLocomotion.HandleRotation(delta);
        }

        private void LateUpdate()
        {
            inputHandler.rollFlag = false;
            inputHandler.rb_Input = false;
            inputHandler.rt_Input = false;
            inputHandler.lt_Input = false;
            inputHandler.d_Pad_Up = false;
            inputHandler.d_Pad_Down = false;
            inputHandler.d_Pad_Left = false;
            inputHandler.d_Pad_Right = false;
            inputHandler.a_Input = false;
            inputHandler.jump_Input = false;
            inputHandler.inventory_Input = false;

            float delta = Time.deltaTime;

            if (cameraHandler != null)
            {
                cameraHandler.FollowTarget(delta);
                cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
            }

            if (isInAir)
            {
                playerLocomotion.inAirTimer = playerLocomotion.inAirTimer + Time.deltaTime;
            }
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            throw new System.NotImplementedException();
        }
    }

}
