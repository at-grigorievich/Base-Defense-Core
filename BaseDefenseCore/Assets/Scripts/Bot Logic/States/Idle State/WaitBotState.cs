using ATGStateMachine;
using UnityEngine;

namespace BotLogic.States
{
    public class WaitBotState: BaseStatement<IAgent>
    {
        private const float MaxDelayTime = 5f;
        
        private float _needTime;
        private float _curTime;


        public WaitBotState(IAgent mainObject, IStateSwitcher stateSwitcher) 
            : base(mainObject, stateSwitcher)
        {
        }

        public override void Enter()
        {
            MainObject.AnimatorService.AnimateIdle();

            _needTime = Random.Range(.25f, MaxDelayTime);
            _curTime = 0f;
        }

        public override void Exit()
        {
            //_curTime = 0f;
        }

        public override void Execute()
        {
            _curTime += Time.deltaTime;

            if (_curTime >= _needTime)
            {
                StateSwitcher.StateSwitcher<RunBotState>();
            }
        }
    }
}