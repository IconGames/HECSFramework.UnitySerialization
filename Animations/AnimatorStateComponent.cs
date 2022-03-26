using HECSFramework.Core;
using HECSFramework.Unity;
using UnityEngine;

namespace Components
{
    public sealed partial class AnimatorStateComponent : IHaveActor, IInitable
    {
        public IActor Actor { get; set; }

        public void Init()
        {
            Actor.TryGetComponent(out Animator animator, true);
            State = AnimatorManager.GetAnimatorState(animator.runtimeAnimatorController.name);
        }
    }
}