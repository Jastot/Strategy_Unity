namespace DefaultNamespace
{
    public interface IAwaitable<TResult>
    {
        IAwaiter<TResult> GetAwaiter();
    }
}