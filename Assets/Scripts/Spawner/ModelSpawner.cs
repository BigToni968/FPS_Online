using System.Collections.Generic;
using Game.Data;
using Patterns;
using System;

namespace Game.Models
{
    [Serializable]
    public struct SpawnerData
    {
        public List<SOUnit> Units;
    }

    [Serializable]
    public class ModelSpawner : Model<SpawnerData>
    {
    }
}