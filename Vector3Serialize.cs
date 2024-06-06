﻿using MessagePack;
using Newtonsoft.Json;
using UnityEngine;

namespace HECSFramework.Core
{
    public partial struct Vector3Serialize
    {
        public Vector3Serialize(Vector3 source)
        {
            X = source.x;
            Y = source.y;
            Z = source.z;
        }
        
        [IgnoreMember]
        [JsonIgnore]
        public Vector3 AsVector
            => new Vector3(X, Y, Z);

        public void SetVector3Serialize(Vector3 source)
        {
            X = source.x;
            Y = source.y;
            Z = source.z;
        }
    }
}