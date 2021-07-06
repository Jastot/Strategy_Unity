using System.Runtime.CompilerServices;

namespace DefaultNamespace
{
    public interface IAwaiter<TResult> : INotifyCompletion
    { 
        bool IsCompleted { get; }
        TResult GetResult();
    }
}