using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class CharacterManager : MonoBehaviourPunCallbacks, IPunObservable
    {
        [Header("Lock On Transform")]
        public Transform lockOnTransform;

        [Header("Combat Colliders")]
        public CriticalDamageCollider backStabCollider;
        public CriticalDamageCollider riposteCollider;

        [Header("Combat Flags")]
        public bool canBeRiposted;
        public bool canBeParried;
        public bool isParrying;
        public bool isBlocking;

        [Header("Spells")]
        public bool isFiringSpell;

        //Damage will be inflicted during an animation event
        //Used in backstab or riposte animations
        public int pendingCriticalDamage;

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            throw new System.NotImplementedException();
        }
    }
}