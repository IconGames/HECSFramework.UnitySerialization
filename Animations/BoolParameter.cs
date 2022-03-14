namespace HECSFramework.Serialize
{
    public sealed partial class BoolParameter : AnimatorParameter<bool>
    {
        protected override void SetValueToAnimator()
        {
            base.SetValueToAnimator();
            Animator.SetBool(parameterHashCode, Value);
        }
    }
}
