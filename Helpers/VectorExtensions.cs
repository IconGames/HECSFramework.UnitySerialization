using HECSFramework.Core;
using UnityEngine;

namespace Helpers
{
    public static partial class VectorExtensions
    {
        public static Vector3 ToNumericsV3(this Vector3Serialize vector3)
          => new Vector3(vector3.X, vector3.Y, vector3.Z);
    }
}