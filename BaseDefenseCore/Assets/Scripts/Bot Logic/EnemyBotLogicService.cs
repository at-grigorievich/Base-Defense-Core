using System;
using BotLogic.States;
using UnityEngine;

namespace BotLogic
{
    public class EnemyBotLogicService: BotLogicService
    {
        protected new void Start()
        {
            
        }
        
        public void InitEnemy(Func<Vector3> getRndPosition)
        {
            var movementBehaviour = new EnemyRunStateBehaviour(getRndPosition);

            AllStates.Add(new WaitBotState(this,this));
            AllStates.Add(new RunBotState(this,this,movementBehaviour));
            InitBot();   
        }
    }
}