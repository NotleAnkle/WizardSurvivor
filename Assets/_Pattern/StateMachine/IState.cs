namespace _Framework.StateMachine
{
    public interface IState<in T>
    {
        void OnEnter(T t);
        void OnExecute(T t);
        void OnExit(T t);
    }
}
