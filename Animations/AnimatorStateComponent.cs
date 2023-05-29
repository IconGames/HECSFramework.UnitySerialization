using System;
using HECSFramework.Core;
using HECSFramework.Unity;
using UnityEngine;

namespace Components
{
    public sealed partial class AnimatorStateComponent : IHaveActor, IInitable, IInitAfterView, IDisposable
    {
        public Actor Actor { get; set; }
        public Animator Animator;
        public bool Activated;

        public void Init()
        {
            if (Owner.ContainsMask<ViewReferenceGameObjectComponent>())
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
            Activated = true;
        }

        public void SetTrigger(int id)
        {
            Animator.SetTrigger(id);
        }

        public void InitAferView()
        {
            SetupAnimatorState();
        }

        public void Dispose()
        {
            Activated = false;
        }
    }
}