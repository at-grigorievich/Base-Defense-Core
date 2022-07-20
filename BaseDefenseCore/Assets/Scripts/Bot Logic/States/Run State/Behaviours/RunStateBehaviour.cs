using ATGStateMachine;

namespace BotLogic.States
{
    public class RunStateBehaviour: IStrategyStateBehaviour<IAgent>
    {
        protected IAgent _agent;
        protected IStateSwitcher _stateSwitcher;
        
        public void Init(IAgent go, IStateSwitcher stateSwitcher)
        {
            _agent = go;
            _stateSwitcher = stateSwitcher;
        }

        public virtual void Enter(){}
        public virtual void Execute(){}
        public virtual void Exit(){}
    }
}