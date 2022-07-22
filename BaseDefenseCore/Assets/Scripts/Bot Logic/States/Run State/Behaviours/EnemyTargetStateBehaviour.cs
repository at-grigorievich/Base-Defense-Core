using System;
using FightService;
using Vector3 = UnityEngine.Vector3;

namespace BotLogic.States
{
    public class EnemyTargetStateBehaviour: RunStateBehaviour
    {
        private const float Distance = .75f;

        private readonly AttackService _attackService;
        private readonly ITargetable _targetable;

        private readonly Action _resetRunBehaviour;
        
        public EnemyTargetStateBehaviour(ITargetable target, Action resetCallback,
            AttackService attackService)
        {
            _targetable = target;
            _attackService = attackService;
            
            _resetRunBehaviour = resetCallback;
        }

        public override void Enter()
        {
            _agent.AnimatorService.AnimateRun();
        }

        public override void Execute()
        {
            if (!_targetable.IsTargetAvailable)
            {
                _resetRunBehaviour?.Invoke();
                _agent.MovableService.SetActiveMove(true);
                _stateSwitcher.StateSwitcher<WaitBotState>();
                return;
            }
            
            var target = _targetable.TargetPosition;
            target.y = _agent.CurrentPosition.y;
            
            if (Vector3.Distance(_agent.CurrentPosition, target) > _attackService.Distance)
            {
                _agent.AnimatorService.AnimateRun();
                
                _agent.MovableService.SetActiveMove(false);
                _agent.MovableService.Move(target);
                _agent.MovableService.Rotate(Vector3.zero,0f);
            }
            else
            {
                _agent.AnimatorService.AnimateIdle();
                _agent.MovableService.SetActiveMove(true);
                
                _attackService.TryAttack();
            }
        }
    }
}