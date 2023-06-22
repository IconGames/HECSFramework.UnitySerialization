using HECSFramework.Serialize;

namespace Components
{
    [JSONHECSSerialize]
    public sealed partial class SoundVolumeComponent: ISavebleComponent
    {
        [Field(0)]
        public bool IsSoundOn;
    }
}