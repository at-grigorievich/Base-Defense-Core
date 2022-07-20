namespace ATGStateMachine
{
    public interface IStrategyStateBehaviour<T>
    {
        void Init(T go, IStateSwitcher stateSwitcher);
        void Enter();
        void Execute();
        void Exit();
    }
}