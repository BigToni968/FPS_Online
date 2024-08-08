using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Game.Spawn;
using Game.Units;
using Game.Data;
using Zenject;
using Game.UI;

namespace Game.Installers
{
    public class SpawnerInstaller : MonoInstaller
    {
        [field: SerializeField] public CinemachineVirtualCamera Camera { get; private set; }
        [field: SerializeField] public SOSpawner SOSpawner { get; private set; }
        [field: SerializeField] public List<SpawnPoint> SpawnPoints { get; private set; }

        private ISpawner _spawner;

        public override void InstallBindings()
        {
            _spawner = new Spawner();
            _spawner.Init((SOSpawner.Model.Data, Camera));
            Container.BindInstance<ISpawner>(_spawner).AsSingle();
        }

        public override void Start()
        {
            base.Start();

            foreach (SOUnit unit in _spawner.Model.Units)
            {
                IUnit unitInstance = _spawner.Spawn(SpawnPoints[Random.Range(0, SpawnPoints.Count - 1)].Position, unit);
                unitInstance.Constuctor(Container);

                if (unitInstance.GetType().Equals(typeof(Player)))
                {
                    Container.BindInstance<IUnit>(unitInstance).WithId(typeof(Player)).AsSingle();
                    IUI_Manager m = Container.TryResolve<IUI_Manager>();
                    m.Get<IUI_Inventory>().Init(unitInstance);
                }
            }
        }

        private void Update()
        {
            _spawner.OnUpdate();
        }
    }
}