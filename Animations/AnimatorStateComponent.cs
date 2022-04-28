using HECSFramework.Core;
using HECSFramework.Unity;
using UnityEngine;

namespace Components
{
    public sealed partial class AnimatorStateComponent : IHaveActor, IInitable
    {
        public IActor Actor { get; set; }
        private Animator animator;

        public void Init()
        {
            Actor.TryGetComponent(out animator, true);
            State = AnimatorManager.GetAnimatorState(animator.runtimeAnimatorController.name);
            State.SetAnimator(animator);
        }

        public void SetTrigger(int id)
        {
            animator.SetTrigger(id);
        }
    }
}