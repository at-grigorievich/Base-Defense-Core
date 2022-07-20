using ATGStateMachine;
using BotLogic.Moving;
using BotLogic.Services.Animator;
using Zenject;

namespace BotLogic
{
    public class BotLogicService : StatementBehaviour<IAgent>,IAgent
    {
        [Inject] public BotAnimatorService AnimatorService { get; private set; }
        [Inject] public MovableService MovableService { get; private set; }

        private void Update() => OnExecute();

        protected void InitBot()
        {
            InitStartState();
            OnState();
        }
        
        public class Factory: PlaceholderFactory<UnityEngine.Object,BotLogicService> {}
    }
}