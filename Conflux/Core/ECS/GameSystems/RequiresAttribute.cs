using Conflux.Core.ECS.Components;
using System;
using System.Collections.Generic;

namespace Conflux.Core.ECS.GameSystem
{
    public class RequiresAttribute : Attribute
    {
        public List<IComponent> RequiredComponents;

        public RequiresAttribute(params IComponent[] requiredComponents)
        {
            RequiredComponents = new List<IComponent>();

            foreach (IComponent c in requiredComponents)
                RequiredComponents.Add(c);
        }
    }
}
