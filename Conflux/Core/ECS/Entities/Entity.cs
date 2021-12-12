using Conflux.Core.ECS.Components;

namespace Conflux.Core.ECS.Entities
{
    public struct Entity
    {
        public readonly int id;

        public Entity(int _id)
        {
            id = _id;
        }

        public bool HasComponent<T>() 
            where T : IComponent
        {
            return ComponentManager.GetComponent<T>(id);
        }
    }
}
