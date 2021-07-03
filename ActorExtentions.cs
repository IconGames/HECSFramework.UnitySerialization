using Components;
using HECSFramework.Core;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace HECSFramework.Unity
{
    public static partial class ActorExtentions
    {
        public static async Task<IActor> GetActor(this IEntity entity, Action<IActor> callBack = null)
        {
            if (entity == null)
                throw new Exception("entity == null");

            var save = new EntityResolver().GetEntityResolver(entity);

            if (entity.TryGetHecsComponent(out ActorContainerID container))
            {
                var actorContainer = await Addressables.LoadAssetAsync<ScriptableObject>(container.ID).Task;
                var data = entity.GetHECSComponent<ViewReferenceComponent>().ViewReference.InstantiateAsync();
                var actorPrfb = await data.Task;
                (actorContainer as EntityContainer).Init(actorPrfb);
                await actorPrfb.LoadEntityFromResolver(save);
                Addressables.Release(data);
                callBack?.Invoke(actorPrfb);
                return actorPrfb;
            }

            throw new Exception("All going to second anus, because we dont have actor container id " + entity.ID);
        }
    }
}