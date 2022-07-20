using System;
using BotLogic.States;
using InputService;
using LevelControlLogic;
using Zenject;

namespace BotLogic
{
    public class PlayerBotLogicService: BotLogicService
    {
        [Inject]
        private void Constructor(IGameStatusListener status,PlayerInputService _input)
        {
            var movementBehaviour = new PlayerRunStateBehaviour(_input, _smoothing);
            
            Func<bool> tryToMove = () => _input.JoystickValue.magnitude > 0.05f;
            
            AllStates.Add(new IdleBotState(this,this,tryToMove));
            AllStates.Add(new RunBotState(this,this,movementBehaviour));
            
            status.OnGameStart += InitBot;
        }
    }
}