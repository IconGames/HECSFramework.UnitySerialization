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
                Transform.position = PositionSave.AsVector;
                Transform.rotation = UnityEngine.Quaternion.Euler(RotationSave.AsVector);
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