namespace ATGStateMachine
{
    public class BaseStrategyStatement<T>: BaseStatement<T>
    {
        private readonly IStrategyStateBehaviour<T> _strategyState;
        
        public BaseStrategyStatement(T mainObject, IStateSwitcher stateSwitcher,IStrategyStateBehaviour<T> strategyState) 
            : base(mainObject, stateSwitcher)
        {
            _strategyState = strategyState;
            _strategyState.Init(mainObject,stateSwitcher);
        }

        public override void Enter() => _strategyState.Enter();
        public override void Execute() => _strategyState.Execute();
        public override void Exit() => _strategyState.Exit();
    }
}