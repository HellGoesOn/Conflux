using Conflux.Core.ECS.Entities;
using System.Collections.Generic;

namespace Conflux.Core.ECS.World
{
    public class GameWorld
    {
        private List<Entity> entities;

        private GameWorld()
        {
            entities = new List<Entity>();
        }
    }
}
