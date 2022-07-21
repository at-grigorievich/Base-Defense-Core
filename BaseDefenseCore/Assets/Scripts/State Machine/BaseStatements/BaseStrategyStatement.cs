namespace ATGStateMachine
{
    public class BaseStrategyStatement<T>: BaseStatement<T>
    {
        private IStrategyStateBehaviour<T> _strategyState;
        
        
        public BaseStrategyStatement(T mainObject, IStateSwitcher stateSwitcher,IStrategyStateBehaviour<T> strategyState) 
            : base(mainObject, stateSwitcher)
        {
            UpdateStatementBehaviour(strategyState);
        }

        public void UpdateStatementBehaviour(IStrategyStateBehaviour<T> strategyState)
        {
            _strategyState = strategyState;
            _strategyState.Init(MainObject,StateSwitcher);
        }
        
        public override void Enter() => _strategyState.Enter();
        public override void Execute() => _strategyState.Execute();
        public override void Exit() => _strategyState.Exit();
    }
}