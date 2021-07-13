using UnityEngine;

namespace HECSFramework.Core
{
    public partial struct Vector3Serialize
    {
        public Vector3 GetVector3()
        {
            return new Vector3(X, Y, Z);
        }

        public void SetVector3Serialize(Vector3 xyz)
        {
            X = xyz.x;
            Y = xyz.y;
            Z = xyz.z;
        }
    }
}