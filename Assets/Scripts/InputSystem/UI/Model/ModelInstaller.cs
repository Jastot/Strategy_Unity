using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class ModelInstaller: MonoInstaller
    {
        [SerializeField] private AssetStorage _assets;
        [SerializeField] private GroundClickModel _groundClick;
        [SerializeField] private SelectedItemModel _selectedItem;
        [SerializeField] private AttackableTargetModel _dummyTarget;
        [SerializeField] private HoldPositionModel _holdPositionModel;
        
        public override void InstallBindings()
        {
            Container.Bind<AssetStorage>().FromInstance(_assets).AsSingle();

            Container.Bind<HoldPositionModel>().FromInstance(_holdPositionModel).AsSingle();
            Container.Bind<GroundClickModel>().FromInstance(_groundClick).AsSingle();
            Container.Bind<SelectedItemModel>().FromInstance(_selectedItem).AsSingle();

            Container.Bind<IAwaitable<Vector3>>().FromInstance(_groundClick).AsSingle();
            Container.Bind<IAwaitable<GameObject>>().FromInstance(_dummyTarget).AsSingle();
            Container.Bind<IAwaitable<bool>>().FromInstance(_holdPositionModel).AsSingle();
            _holdPositionModel.SetValue(false);
            Container.Bind<ControlButtonPanel>().AsSingle();
            
            Container.Bind<CommandCreator<IHoldPosition>>().To<HoldPositionUnitCommandCreator>().AsSingle();
            Container.Bind<CommandCreator<IProduceUnitCommand>>().To<ProduceUnitCommandCreator>().AsSingle();
            Container.Bind<CommandCreator<IAttackCommand>>().To<AttackCommandCreator>().AsSingle();
            Container.Bind<CommandCreator<IMoveCommand>>().To<MoveCommandCreator>().AsSingle();
            Container.Bind<CommandCreator<IStopCommand>>().To<StopCommandCreator>().AsSingle();
            Container.Bind<CommandCreator<IPatrolCommand>>().To<PatrolUnitCommandCreator>().AsSingle();
        }
    }
}