using System;
using ATGStateMachine;

namespace BotLogic.States
{
    public class IdleBotState: BaseStatement<IAgent>
    {
        private readonly Func<bool> _tryToMove;

        public IdleBotState(IAgent mainObject, IStateSwitcher stateSwitcher,
            Func<bool> tryToMove = null ) 
            : base(mainObject, stateSwitcher)
        {
            _tryToMove = tryToMove;
        }

        public override void Enter()
        {
            MainObject.AnimatorService.AnimateIdle();
        }

        public override void Execute()
        {
            bool tryToMove = _tryToMove?.Invoke() ?? true;
            if (tryToMove)
            {
                StateSwitcher.StateSwitcher<RunBotState>();
            }
        }
    }
}