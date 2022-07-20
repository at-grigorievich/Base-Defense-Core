using AnimatorControl;
using BotLogic.Services.Animator;
using UnityEngine;
using Zenject;

namespace BotLogic.Zenject
{
    public class BotAnimatorInstaller: MonoInstaller
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimatorStateData _animatorStates;
        
        public override void InstallBindings()
        {
            var botAnimator = new BotAnimatorService(_animator, _animatorStates);

            Container.BindInstance(botAnimator).AsSingle().NonLazy();
        }
    }
}