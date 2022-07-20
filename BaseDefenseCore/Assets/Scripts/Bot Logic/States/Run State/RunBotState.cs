using ATGStateMachine;

namespace BotLogic.States
{
    public class RunBotState: BaseStrategyStatement<IAgent>
    {
        public RunBotState(IAgent mainObject, IStateSwitcher stateSwitcher, 
            IStrategyStateBehaviour<IAgent> strategyState) 
            : base(mainObject, stateSwitcher, strategyState)
        {
        }
    }
}