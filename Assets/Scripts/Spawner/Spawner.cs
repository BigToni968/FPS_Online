using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Game.Models;
using Game.Units;
using Game.Data;

namespace Game.Spawn
{
    public interface ISpawner : IInitialization<(SpawnerData data, CinemachineVirtualCamera virCamera)>, IUpdater
    {
        public CinemachineVirtualCamera VirCamera { get; }
        public SpawnerData Model { get; }
        public ISpawnStorage Storage { get; }

        public IUnit Spawn(Vector3 position, SOUnit soUnit);
    }

    public class Spawner : ISpawner
    {
        public CinemachineVirtualCamera VirCamera { get; private set; }
        public SpawnerData Model { get; private set; }
        public ISpawnStorage Storage { get; private set; }

        public void Init((SpawnerData data, CinemachineVirtualCamera virCamera) data)
        {
            Model = data.data;
            VirCamera = data.virCamera;
            Storage = new SpawnerStorage();
        }


        public IUnit Spawn(Vector3 position, SOUnit soUnit)
        {
            IUnit unit = GameObject.Instantiate(soUnit.Prefab, position, Quaternion.identity);
            unit.Init(soUnit);
            SettingPlayerUnit(unit);
            Storage.Add(unit, SpawnStorageKey.All);
            Storage.Add(unit, SpawnStorageKey.Lifes);
            return unit;
        }

        private void SettingPlayerUnit(IUnit unitPlayer)
        {
            if (!unitPlayer.GetType().Equals(typeof(Player)))
            {
                return;
            }

            Player player = unitPlayer as Player;
            VirCamera.Follow = player.FollowPoint;
            VirCamera.LookAt = player.Look.Face;
        }

        public void OnUpdate()
        {
            Storage.Units.TryGetValue(SpawnStorageKey.Lifes, out HashSet<IUnit> lifes);

            if (lifes != null)
            {
                foreach (IUnit unit in lifes)
                {
                    unit.OnUpdate();

                    if (!unit.IsLive)
                    {
                        Storage.Remove(unit, SpawnStorageKey.Lifes, SpawnStorageKey.Deads);
                    }
                }
            }

        }
    }
}