using System;
using System.Collections;
using BonusItemService;
using BotLogic;
using BotLogic.Data;
using Cinemachine;
using InputService;
using LevelControlLogic;
using UI;
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

        [Inject] private BonusContainerPresenter _bonusPresentor;
        
        [Inject(Id = "Respawn-Panel")] private CallbackPanel _panel;
        
        private PlayerBotSpawnerPoint _spawnerPoint;
        private PlayerBotLogicService _playerBot;

        [Inject]
        private void Constructor(BotLogicService.Factory factory)
        {
            _spawnerPoint = new PlayerBotSpawnerPoint(_playerBotSpawnPoint, factory);
            
            _panel.AddCallback(RespawnPlayerBot);
        }
        
        private IEnumerator Start()
        {
            _playerBot = _spawnerPoint.DoSpawn(_playerBotData.GetBot(BotType.PlayerBot));
            _playerBot.OnDieInPlace += OnDiePlayerBot;
            
            yield return null;
            
            _inputService.SetInputEnable(true);
            SetupCinemachine();
            
            _gameStatusHandler.DoStartGame();
        }

        #region Respawning player bot
        private void OnDiePlayerBot(object sender, Vector3 e)
        {
            if (ReferenceEquals(_playerBot, sender))
            {
                _inputService.SetInputEnable(false);
                Time.timeScale = .1f;
                
                _bonusPresentor.ClearCurrentCount();
                _panel.ShowPanel();
            }
        }
        private void RespawnPlayerBot()
        {
            _inputService.SetInputEnable(true);
            Time.timeScale = 1f;
            _spawnerPoint.DoPlace(_playerBot.transform);
            _playerBot.InitBot();
        }
        #endregion

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
            
            DoPlace(bot.transform);

            if (bot is PlayerBotLogicService playerBot)
                return playerBot;

            throw new ArgumentException("prefab isnt Player Bot !");
        }

        public void DoPlace(Transform transform)
        {
            transform.position = _spawnPoint.position;
            Vector3 rot = transform.transform.eulerAngles;
            rot.y = _spawnPoint.eulerAngles.y;

            transform.rotation = Quaternion.Euler(rot);
        }
    }
}