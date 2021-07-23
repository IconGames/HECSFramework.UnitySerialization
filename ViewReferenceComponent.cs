using HECSFramework.Core;

namespace Components
{
    public partial class ViewReferenceComponent : BaseComponent, IBeforeSerializationComponent
    {
        public void BeforeSync()
        {
            this.AssetReferenceGuid = ViewReference.AssetGUID;
        }
    }
}