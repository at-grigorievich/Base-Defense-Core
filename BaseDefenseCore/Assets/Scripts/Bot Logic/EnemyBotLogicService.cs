using System;
using ATGStateMachine;
using BotLogic.States;
using UnityEngine;

namespace BotLogic
{
    public class EnemyBotLogicService: BotLogicService
    {
        private RunBotState _runState;
        private IStrategyStateBehaviour<IAgent> _defaultRunBeh;

        private ITargetable _targetCache;
        
        protected new void Start() {}
        
        public void InitEnemy(Func<Vector3> getRndPosition)
        {
            _defaultRunBeh = new EnemyRunStateBehaviour(getRndPosition);

            _runState = new RunBotState(this, this, _defaultRunBeh);
            
            AllStates.Add(new WaitBotState(this,this));
            AllStates.Add(_runState);
            InitBot();   
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out ITargetable targetable))
            {
                if (!ReferenceEquals(targetable, _targetCache))
                {
                    StartTargetFollowing(targetable);
                }
            }
        }
        
        private void StartTargetFollowing(ITargetable targetObj)
        {
            if (targetObj.IsTargetAvailable)
            {
                _targetCache = targetObj;
                
                var targetBehaviour = new EnemyTargetStateBehaviour(targetObj, 
                    ResetDefaultRunBehaviour,AttackService);
                _runState.UpdateStatementBehaviour(targetBehaviour);
                
                StateSwitcher<RunBotState>();
            }
        }

        private void ResetDefaultRunBehaviour()
        {
            _runState.UpdateStatementBehaviour(_defaultRunBeh);
            _targetCache = null;
        }

        protected override void DieBot()
        {
            StateSwitcher<WaitBotState>();
            ResetDefaultRunBehaviour();
            base.DieBot();
        }
    }
}