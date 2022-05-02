using HECSFramework.Core;
using HECSFramework.Unity;
using UnityEngine;

namespace Components
{
    public sealed partial class AnimatorStateComponent : IHaveActor, IInitable
    {
        public IActor Actor { get; set; }
        public Animator Animator;

        public void Init()
        {
            Actor.TryGetComponent(out Animator, true);
            State = AnimatorManager.GetAnimatorState(Animator.runtimeAnimatorController.name);
            State.SetAnimator(Animator);
        }

        public void SetTrigger(int id)
        {
            Animator.SetTrigger(id);
        }
    }
}