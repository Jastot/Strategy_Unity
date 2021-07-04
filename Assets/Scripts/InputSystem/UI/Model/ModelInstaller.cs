using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class ModelInstaller: MonoInstaller
    {
        [SerializeField] private AssetStorage _assets;
        
        public override void InstallBindings()
        {
            Container.Bind<AssetStorage>().FromInstance(_assets).AsSingle();

            Container.Bind<ControlButtonPanel>().AsSingle();

            Container.Bind<CommandCreator<IProduceUnitCommand>>().To<ProduceUnitCommandCreator>().AsSingle();
            Container.Bind<CommandCreator<IAttackCommand>>().To<AttackCommandCreator>().AsSingle();
            Container.Bind<CommandCreator<IMoveCommand>>().To<MoveCommandCreator>().AsSingle();
            Container.Bind<CommandCreator<IStopCommand>>().To<StopCommandCreator>().AsSingle();
        }
    }
}