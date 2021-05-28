using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class InputHandler : MonoBehaviour
    {
        public float horizontal;
        public float vertical;
        public float moveAmount;
        public float mouseX;
        public float mouseY;

        public bool b_Input;
        public bool a_Input;
        public bool y_Input;
        public bool rb_Input;
        public bool rt_Input;
        public bool lb_Input;
        public bool lt_Input;
        public bool critical_Attack_Input;
        public bool jump_Input;
        public bool inventory_Input;
        public bool lockOnInput;
        public bool right_Stick_Right_Input;
        public bool right_Stick_Left_Input;

        public bool d_Pad_Up;
        public bool d_Pad_Down;
        public bool d_Pad_Left;
        public bool d_Pad_Right;

        public bool rollFlag;
        public bool twoHandFlag;
        public bool sprintFlag;
        public bool comboFlag;
        public bool lockOnFlag;
        public bool inventoryFlag;
        public float rollInputTimer;

        public Transform criticalAttackRayCastStartPoint;

        PlayerControls inputActions;
        PlayerAttacker playerAttacker;
        PlayerManager playerManager;
        PlayerStats playerStats;
        CameraHandler cameraHandler;
        PlayerAnimatorManager animatorHandler;
        Vector2 movementInput;
        Vector2 cameraInput;

        private void Awake()
        {
            playerAttacker = GetComponentInChildren<PlayerAttacker>();
            
            playerManager = GetComponent<PlayerManager>();
            playerStats = GetComponent<PlayerStats>();
            animatorHandler = GetComponentInChildren<PlayerAnimatorManager>();
        }
        private void Start()
        {
            cameraHandler = FindObjectOfType<CameraHandler>();
        }
        public void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerControls();
                inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
                inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
                inputActions.PlayerActions.RB.performed += i => rb_Input = true;
                inputActions.PlayerActions.RT.performed += i => rt_Input = true;
                //inputActions.PlayerActions.LB.performed += i => lb_Input = true;
                //inputActions.PlayerActions.LB.canceled += i => lb_Input = false;
                //inputActions.PlayerActions.LT.performed += i => lt_Input = true;
                //inputActions.PlayerQuickSlots.DPadRight.performed += i => d_Pad_Right = true;
                //inputActions.PlayerQuickSlots.DPadLeft.performed += i => d_Pad_Left = true;
                //inputActions.PlayerActions.A.performed += i => a_Input = true;
                inputActions.PlayerActions.Roll.performed += i => b_Input = true;
                inputActions.PlayerActions.Roll.canceled += i => b_Input = false;
                //inputActions.PlayerActions.Jump.performed += i => jump_Input = true;
                //inputActions.PlayerActions.Inventory.performed += i => inventory_Input = true;
                //inputActions.PlayerActions.LockOn.performed += i => lockOnInput = true;
                //inputActions.PlayerMovement.LockOnTargetRight.performed += i => right_Stick_Right_Input = true;
                //inputActions.PlayerMovement.LockOnTargetLeft.performed += i => right_Stick_Left_Input = true;
                //inputActions.PlayerActions.Y.performed += i => y_Input = true;
                //inputActions.PlayerActions.CriticalAttack.performed += i => critical_Attack_Input = true;
            }

            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        public void TickInput(float delta)
        {
            HandleMoveInput(delta);
            HandleRollInput(delta);
            HandleCombatInput(delta);
            //HandleQuickSlotsInput();
            //HandleInventoryInput();
            //HandleLockOnInput();
            //HandleTwoHandInput();
            //HandleCriticalAttackInput();
        }

        private void HandleMoveInput(float delta)
        {
            horizontal = movementInput.x;
            vertical = movementInput.y;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
            mouseX = cameraInput.x;
            mouseY = cameraInput.y;
        }

        private void HandleRollInput(float delta)
        {
            if (b_Input)
            {
                rollInputTimer += delta;

                if (moveAmount > 0.5f)
                {
                    sprintFlag = true;
                }
            }
            else
            {
                sprintFlag = false;

                if (rollInputTimer > 0 && rollInputTimer < 0.5f)
                {
                    rollFlag = true;
                }

                rollInputTimer = 0;
            }
        }

        private void HandleCombatInput(float delta)
        {

            if (rb_Input)
            {
                playerAttacker.HandleRBAction();
            }

            if (rt_Input)
            {
                playerAttacker.HandleHeavyAttack();
            }
        }

        private void HandleLockOnInput()
        {
            if (lockOnInput && lockOnFlag == false)
            {
                lockOnInput = false;
                cameraHandler.HandleLockOn();
                if (cameraHandler.nearestLockOnTarget != null)
                {
                    cameraHandler.currentLockOnTarget = cameraHandler.nearestLockOnTarget;
                    lockOnFlag = true;
                }
            }
            else if (lockOnInput && lockOnFlag)
            {
                lockOnInput = false;
                lockOnFlag = false;
                cameraHandler.ClearLockOnTargets();
            }

            if (lockOnFlag && right_Stick_Left_Input)
            {
                right_Stick_Left_Input = false;
                cameraHandler.HandleLockOn();
                if (cameraHandler.leftLockTarget != null)
                {
                    cameraHandler.currentLockOnTarget = cameraHandler.leftLockTarget;
                }
            }

            if (lockOnFlag && right_Stick_Right_Input)
            {
                right_Stick_Right_Input = false;
                cameraHandler.HandleLockOn();
                if (cameraHandler.rightLockTarget != null)
                {
                    cameraHandler.currentLockOnTarget = cameraHandler.rightLockTarget;
                }
            }

            cameraHandler.SetCameraHeight();
        }

    }
}