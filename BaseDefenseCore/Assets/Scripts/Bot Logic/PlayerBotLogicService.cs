using System;
using BotLogic.Data;
using BotLogic.States;
using InputService;
using LevelControlLogic;
using UnityEngine;
using Zenject;

namespace BotLogic
{
    public class PlayerBotLogicService: BotLogicService, 
        ITargetable, IEnemyTracker
    {
        private EnemyTrackerService _enemyTracker;
        
        public bool IsTargetAvailable { get; private set; }
        public Vector3 TargetPosition => CurrentPosition;
        
        
        [Inject]
        private void Constructor(IGameStatusListener status,PlayerInputService _input)
        {
            var movementBehaviour = new PlayerRunStateBehaviour(_input, _smoothing);
            
            Func<bool> tryToMove = () => _input.JoystickValue.magnitude > 0.05f;
            
            AllStates.Add(new IdleBotState(this,this,tryToMove));
            AllStates.Add(new RunBotState(this,this,movementBehaviour));
            
            status.OnGameStart += InitBot;
        }
        
        private void Awake() => _enemyTracker = new EnemyTrackerService();
        
        private new void Update()
        {
            base.Update();

            if (IsTargetAvailable)
            {
                AttackService.TryAttack();
            }
        }

        
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out EnemyBotLogicService enemy))
                AddEnemy(enemy);
        }
        
        private void OnTriggerExit(Collider other)
        {
            if(other.TryGetComponent(out EnemyBotLogicService enemy))
                RemoveEnemy(enemy);
        }
        
        
        public void AddEnemy(EnemyBotLogicService enemyBot) =>
            _enemyTracker.AddEnemy(enemyBot);
        public void RemoveEnemy(EnemyBotLogicService enemyBot) =>
            _enemyTracker.RemoveEnemy(enemyBot);
        
        
        public Vector3? FindNearby(Vector3 center, float maxDistance) =>
            IsTargetAvailable ? _enemyTracker.FindNearby(center, maxDistance) : null;

        protected override void DieBot()
        {
            StateSwitcher<IdleBotState>();
            SetTargetAvailable(false);
            
            base.DieBot();
        }
        
        
        public void SetTargetAvailable(bool isAvailable)
        {
            IsTargetAvailable = isAvailable;
            
            if(!isAvailable)
                _enemyTracker.ClearAll();
        }
    }
}