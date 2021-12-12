namespace Conflux.Core.ECS.Components
{
    internal class ComponentManager
    {
        public static bool GetComponent<T>(int entity) where T : IComponent
        {
            return true;
        }
    }
}
