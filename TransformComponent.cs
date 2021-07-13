using HECSFramework.Core;

namespace Components
{
    [GenerateResolver]
    public partial class TransformComponent : IAfterSerializationComponent, IBeforeSerializationComponent
    {
        public void AfterSync()
        {
            if (Transform != null)
            {
                Transform.position = PositionSave.GetVector3();
                Transform.rotation = UnityEngine.Quaternion.Euler(RotationSave.GetVector3());
            }
        }

        public void BeforeSync()
        {
            if (Transform != null)
            {
                PositionSave.SetVector3Serialize(Transform.position);
                RotationSave.SetVector3Serialize(Transform.rotation.eulerAngles);
            }
        }
    }
}