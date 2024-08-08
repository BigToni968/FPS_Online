using System.Collections.Generic;
using Game.Units;

namespace Game.Spawn
{
    public enum SpawnStorageKey
    {
        All,
        Lifes,
        Deads
    }

    public interface ISpawnStorage
    {
        public IReadOnlyDictionary<SpawnStorageKey, HashSet<IUnit>> Units { get; }

        public bool Add(IUnit unit, SpawnStorageKey to);
        public bool Delate(IUnit unit, SpawnStorageKey from);
        public void Remove(IUnit unit, SpawnStorageKey from, SpawnStorageKey to);
    }

    public class SpawnerStorage : ISpawnStorage
    {
        public IReadOnlyDictionary<SpawnStorageKey, HashSet<IUnit>> Units => _units;

        private Dictionary<SpawnStorageKey, HashSet<IUnit>> _units;

        public SpawnerStorage()
        {
            _units = new();
            _units.Add(SpawnStorageKey.All, new HashSet<IUnit>());
            _units.Add(SpawnStorageKey.Lifes, new HashSet<IUnit>());
            _units.Add(SpawnStorageKey.Deads, new HashSet<IUnit>());
        }

        public void Remove(IUnit unit, SpawnStorageKey from, SpawnStorageKey to)
        {
            if (Delate(unit, from))
            {
                Add(unit, to);
            }
        }

        public bool Add(IUnit unit, SpawnStorageKey to)
        {
            if (_units.ContainsKey(to))
            {
                _units.TryGetValue(to, out HashSet<IUnit> units);
                return units.Add(unit);
            }

            return false;
        }

        public bool Delate(IUnit unit, SpawnStorageKey from)
        {
            if (_units.ContainsKey(from))
            {
                _units.TryGetValue(from, out HashSet<IUnit> units);
                return units.Remove(unit);
            }

            return false;
        }
    }
}