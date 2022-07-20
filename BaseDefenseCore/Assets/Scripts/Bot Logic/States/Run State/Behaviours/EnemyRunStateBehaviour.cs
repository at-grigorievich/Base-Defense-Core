using System;
using UnityEngine;

namespace BotLogic.States
{
    public class EnemyRunStateBehaviour: RunStateBehaviour
    {
        private readonly Func<Vector3> _targetGenerator;

        private Vector3 _targetPosition;
        
        public EnemyRunStateBehaviour(Func<Vector3> nextPosGenerator)
        {
            _targetGenerator = nextPosGenerator;
        }

        public override void Enter()
        {
            _agent.AnimatorService.AnimateRun();
            _targetPosition = GenerateTargetPosition();
        }

        public override void Execute()
        {
            if (Vector3.Distance(_agent.CurrentPosition, _targetPosition) > Mathf.Epsilon)
            {
                _agent.MovableService.Move(_targetPosition);
                _agent.MovableService.Rotate(_targetPosition,0f);
            }
            else
            {
                _stateSwitcher.StateSwitcher<WaitBotState>();
            }
        }


        private Vector3 GenerateTargetPosition()
        {
            Vector3 genPosition = _targetGenerator();
            genPosition.y = _agent.CurrentPosition.y;

            return genPosition;
        }
    }
}