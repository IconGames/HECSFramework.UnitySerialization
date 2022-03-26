using HECSFramework.Core;
using UnityEngine;

namespace Components
{
    public partial class TransformComponent : IAfterSerializationComponent, IBeforeSerializationComponent
    {
        public void AfterSync()
        {
            if (Transform != null)
            {
                Transform.position = PositionSave.AsVector;
                Transform.rotation = Quaternion.Euler(RotationSave.AsVector);
            }
        }

        public void BeforeSync()
        {
            if (Transform != null)
            {
                PositionSave = new Vector3Serialize(Transform.position);
                RotationSave = new Vector3Serialize(Transform.rotation.eulerAngles);

                if (Owner.TryGetHecsComponent(HMasks.SavePositionComponent, out SavePositionComponent savePositionComponent))
                {
                    savePositionComponent.Position = PositionSave;
                    savePositionComponent.Rotation = RotationSave;
                }
            }
        }
    }
}