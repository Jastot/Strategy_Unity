using System;
using System.Threading;
using Abstractions;
using UnityEngine;
using Utils;
using Zenject;

namespace Model
{
    public abstract class CommandCreator<T> where T : ICommand
    {
        public void CreateCommand(ICommandExecutor executor, Action<T> onCreate)
        {
            if (executor as CommandExecutorBase<T>)
            {
                CreateSpecificCommand(onCreate);
            }
        }

        protected abstract void CreateSpecificCommand(Action<T> onCreate);
        public abstract void CancelCommand();
    }

    // public abstract class PressedCreator<T> :  CommandCreator<T> where T : ICommand
    // {
    //     protected override void CreatePressedSpecificCommand(Action<T> onCreate)
    //     {
    //         
    //     }
    //     protected abstract T GetCommand();
    // }

    public abstract class CancelableCommandCreator<T, TParam> : CommandCreator<T> where T : ICommand
    {
        private CancellationTokenSource _tokenSource;
        [Inject] private IAwaitable<TParam> _param;

        protected override async void CreateSpecificCommand(Action<T> onCreate)
        {
            _tokenSource = new CancellationTokenSource();
            try
            {
                var paramResult = await _param.AsTask().WithCancellation(_tokenSource.Token);
                onCreate?.Invoke(GetCommand(paramResult));
            }
            catch (OperationCanceledException e)
            {
                Debug.Log("Operation Cancelled");
            }
        }

        protected abstract T GetCommand(TParam param);

        public override void CancelCommand()
        {
            if (_tokenSource != null)
            {
                _tokenSource.Cancel();
                _tokenSource.Dispose();
                _tokenSource = null;
            }
        }
    }


    public class ProduceUnitCommandCreator : CommandCreator<IProduceUnitCommand>
    {
        [Inject] private AssetStorage _assets;

        protected override void CreateSpecificCommand(Action<IProduceUnitCommand> onCreate)
        {
            onCreate?.Invoke(_assets.Inject(new ProduceUnitCommand()));
        }

        public override void CancelCommand()
        {
        }
    }

    public class AttackCommandCreator : CancelableCommandCreator<IAttackCommand, GameObject>
    {
        protected override IAttackCommand GetCommand(GameObject param) => new AttackUnitCommand(param);
    }

    public class MoveCommandCreator : CancelableCommandCreator<IMoveCommand, Vector3>
    {
        protected override IMoveCommand GetCommand(Vector3 param) => new MoveUnitCommand(param);
    }

    public class StopCommandCreator : CancelableCommandCreator<IStopCommand, Vector3>
    {
        protected override IStopCommand GetCommand(Vector3 param) => new StopUnitCommand(param);
    }

    public class PatrolUnitCommandCreator : CancelableCommandCreator<IPatrolCommand, Vector3>
    {
        [Inject] private SelectedItemModel _selectedItem;

        protected override IPatrolCommand GetCommand(Vector3 param) =>
            new PatrolUnitCommand(_selectedItem.Value.CurrentPosition, param);
    }

    public class HoldPositionUnitCommandCreator : CancelableCommandCreator<IHoldPosition,bool>
    {
        protected override IHoldPosition GetCommand(bool param)=>
            new HoldPositionUnitCommand(param);
    }

}