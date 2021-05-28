using SG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class WeaponManager : MonoBehaviour
    {
        DamageCollider rightHandDamageCollider;
        [SerializeField]
            GameObject Weapon;
        private void Awake()
        {
            rightHandDamageCollider = gameObject.GetComponentInChildren<DamageCollider>();
        }
        public void OpenRightDamageCollider()
        {
            rightHandDamageCollider.EnableDamageCollider();
        }

        public void CloseRightHandDamageCollider()
        {
            rightHandDamageCollider.DisaleDamageCollider();
        }

    }
}
