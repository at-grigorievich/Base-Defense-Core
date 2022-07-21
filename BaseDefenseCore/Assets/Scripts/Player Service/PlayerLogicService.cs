using System;
using System.Collections;
using BotLogic;
using BotLogic.Data;
using Cinemachine;
using InputService;
using LevelControlLogic;
using UnityEngine;
using Zenject;

namespace PlayerService
{
    [RequireComponent(typeof(Collider))]
    public class PlayerLogicService : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _camera;
        [Space(15)]
        [SerializeField] private BotPrefabData _playerBotData;
        [SerializeField] private Transform _playerBotSpawnPoint;

        [Inject] private IGameStatusHandler _gameStatusHandler;
        [Inject] private PlayerInputService _inputService;

        private PlayerBotSpawnerPoint _spawnerPoint;
        private PlayerBotLogicService _playerBot;

        [Inject]
        private void Constructor(BotLogicService.Factory factory)
        {
            _spawnerPoint = new PlayerBotSpawnerPoint(_playerBotSpawnPoint, factory);
        }
        
        private IEnumerator Start()
        {
            _playerBot = _spawnerPoint.DoSpawn(_playerBotData.GetBot(BotType.PlayerBot));
            
            yield return null;
            
            _inputService.SetInputEnable(true);
            SetupCinemachine();
            
            _gameStatusHandler.DoStartGame();
        }

        private void SetupCinemachine() => _camera.Follow = _playerBot.transform;
    }
    
    public class PlayerBotSpawnerPoint
    {
        private readonly Transform _spawnPoint;
        private readonly BotLogicService.Factory _factory;

        public PlayerBotSpawnerPoint(Transform spawnPoint, BotLogicService.Factory factory)
        {
            _spawnPoint = spawnPoint;
            _factory = factory;
        }

        public PlayerBotLogicService DoSpawn(BotLogicService botPrefab)
        {
            var bot = _factory.Create(botPrefab);
            bot.transform.position = _spawnPoint.position;

            Vector3 rot = bot.transform.eulerAngles;
            rot.y = _spawnPoint.eulerAngles.y;
            
            bot.transform.rotation = Quaternion.Euler(rot);

            if (bot is PlayerBotLogicService playerBot)
                return playerBot;

            throw new ArgumentException("prefab isnt Player Bot !");
        }
    }
}