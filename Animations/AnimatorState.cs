using System.Collections.Generic;
using UnityEngine;

namespace HECSFramework.Serialize
{
    public partial class AnimatorState
    {
        public void SetAnimator(Animator animator)
        {
            SetAnimatorToAnimParameter(boolParameters, animator);
            SetAnimatorToAnimParameter(floatParameters, animator);
            SetAnimatorToAnimParameter(intParameters, animator);
        }

        private void SetAnimatorToAnimParameter<T>(Dictionary<int, T> dictionary, Animator animator) where T: AnimatorParameter
        {
            foreach (var anim in dictionary)
            {
                anim.Value.Animator = animator;
            }
        }
    }
}
