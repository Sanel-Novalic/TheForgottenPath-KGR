using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public abstract class AnimatorManager : MonoBehaviour  
    {
        public abstract void PlayTargetAnimation(string targetAnim, bool isInteracting, bool canRotate = false);

        public virtual void TakeCriticalDamageAnimationEvent()
        {

        }
    }
}