using Game.Units.Controllers;
using Game.Invetorys.Items;
using Game.Invetorys;
using Game.Models;
using UnityEngine;
using Game.Data;
using Zenject;

namespace Game.Units
{
    public interface IUnit : IInitialization<SOUnit>, IUpdater
    {
        public SOUnit SOModel { get; }
        public Animator Animator { get; }
        public Rigidbody RigidBody { get; }
        public Transform Transform { get; }
        public Collider Collider { get; }
        public ModelUnit Model { get; }
        public UnitDetection Detection { get; }
        public IUnitController Controller { get; }
        public IInventory<IItem> Inventory { get; }
        public DiContainer DiContainer { get; }
        public bool IsLive { get; }

        public void Constuctor(DiContainer diContainer);
    }

    public abstract class BaseUnit : MonoConstructor, IUnit
    {
        [field: SerializeField] public SOUnit SOModel { get; private set; }
        [field: SerializeField] public Collider Collider { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public Rigidbody RigidBody { get; private set; }
        [field: SerializeField] public ModelUnit Model { get; private set; }
        [field: SerializeField] public virtual UnitDetection Detection { get; protected set; }

        public bool IsLive => Model.Data.HP > 0f;
        public Transform Transform => transform;
        public IUnitController Controller { get; protected set; }
        public IInventory<IItem> Inventory { get; protected set; }

        public virtual void Init(SOUnit data)
        {
            SOModel = data;
            Model.OnInit(SOModel.ModelUnit.Clone());
        }

        public virtual void OnUpdate()
        {
            Detection?.OnUpdate();
            Controller?.OnUpdate();
        }
    }
}