using UnityEngine;

namespace AnimatorControl
{
    public abstract class AnimatorBehaviour
    {
        protected readonly Animator _animator;
        protected readonly AnimatorStateData _statesData;

        public AnimatorBehaviour(Animator animator,AnimatorStateData stateData)
        {
            _animator = animator;
            _statesData = stateData;
        }
        
        protected void SetOnlyOneState(AnimatorAction action, bool value) =>
            _statesData.SetState(_animator, action, value);

        protected void SetOneState(AnimatorAction action, bool value) =>
            _statesData.SetState(_animator, action, value, true);
    }
}