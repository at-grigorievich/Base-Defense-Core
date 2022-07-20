using AnimatorControl;

namespace BotLogic.Services.Animator
{
    public class BotAnimatorService: AnimatorBehaviour
    {
        public BotAnimatorService(UnityEngine.Animator animator, AnimatorStateData stateData) 
            : base(animator, stateData)
        {
        }

        public void AnimateIdle() => SetOneState(AnimatorAction.Idle, true);
        public void AnimateRun() => SetOneState(AnimatorAction.Run, true);
        public void AnimateAttack() => SetOnlyOneState(AnimatorAction.Fight, true);
    }
}