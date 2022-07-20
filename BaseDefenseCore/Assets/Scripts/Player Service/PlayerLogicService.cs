using System.Collections;
using InputService;
using LevelControlLogic;
using UnityEngine;
using Zenject;

namespace PlayerService
{
    public class PlayerLogicService : MonoBehaviour
    {
        [Inject] private IGameStatusHandler _gameStatusHandler;
        [Inject] private PlayerInputService _inputService;
        
        private IEnumerator Start()
        {
            yield return null;
            
            _gameStatusHandler.DoStartGame();
            _inputService.SetInputEnable(true);
        }
    }
}