using HECSFramework.Core;
using HECSFramework.Unity;
using UnityEngine;

namespace Components
{
    public sealed partial class AnimatorStateComponent : IHaveActor, IInitable, IInitAferView
    {
        public Actor Actor { get; set; }
        public Animator Animator;

        public void Init()
        {
            if (Owner.ContainsMask<SetupAfterViewTagComponent>())
                return;

            SetupAnimatorState();
        }

        public void SetupAnimatorState()
        {
            Actor.TryGetComponent(out Animator, true);

            if (Animator != null && Animator.runtimeAnimatorController is AnimatorOverrideController overrideController)
                State = AnimatorManager.GetAnimatorState(overrideController.runtimeAnimatorController.name);
            else
                State = AnimatorManager.GetAnimatorState(Animator.runtimeAnimatorController.name);

            State.SetAnimator(Animator);
        }

        public void SetTrigger(int id)
        {
            Animator.SetTrigger(id);
        }

        public void InitAferView()
        {
            SetupAnimatorState();
        }
    }
}