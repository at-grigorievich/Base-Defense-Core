using System.Collections;
using BotLogic;
using BotLogic.Data;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace RandomSpawnerService
{
    public class RandomSpawnerService : MonoBehaviour
    {
        private const float DelayBeforeSpawn = 0.25f;
        
        [SerializeField] private BotPrefabData _botPrefabData;
        [Space(10)] 
        [Range(0, 25)] [SerializeField] private int _spawnObjectCount;
        [SerializeField] private Transform _spawnCenter;
        [SerializeField] private float _spawnRadius;

        [Inject] private BotLogicService.Factory _factory;
        
        public EnemyBotLogicService[] EnemyBots { get; private set; }

        private Vector2 _xSize;
        private Vector2 _zSize;

        private void Start()
        {
            var transform1 = _spawnCenter.transform;
            
            float zRangeMax = transform1.position.z + transform1.localScale.z / 2;
            float zRangeMin = transform1.position.z - transform1.localScale.z / 2;

            float xRangeMax = transform1.position.x + transform1.localScale.x / 2;
            float xRangeMin = transform1.position.x - transform1.localScale.x / 2;

            _xSize = new Vector2(xRangeMin, xRangeMax);
            _zSize = new Vector2(zRangeMin, zRangeMax);
            
            StartCoroutine(CreateBots());
        }

        private IEnumerator CreateBots()
        {
            EnemyBots = new EnemyBotLogicService[_spawnObjectCount];

            var ePrefab = _botPrefabData.GetBot(BotType.EnemyBot);
            for (int i = 0; i < EnemyBots.Length; i++)
            {
                    var instance = _factory.Create(ePrefab);
                    
                    //PlaceOnRandomCircle(instance.transform);
                    PlaceOn(instance.transform);
                    
                    if (instance is EnemyBotLogicService enemyBot)
                    {
                        EnemyBots[i] = enemyBot;
                        enemyBot.InitEnemy(GetRandomPosition);
                    }
                    yield return null;
            }
        }

        private void PlaceOnRandomCircle(Transform obj)
        {
            Vector2 rnd = Random.insideUnitCircle * _spawnRadius;

            Vector3 spawnPosition = _spawnCenter.position + new Vector3(rnd.x, 0f, rnd.y);

            obj.transform.position = spawnPosition;
            obj.transform.eulerAngles = new Vector3(0f, Random.value * 360, 0f);
        }

        private void PlaceOn(Transform obj)
        {
            Vector3 spawnPosition = GetRandomPosition();
            
            obj.transform.position = spawnPosition;
            obj.transform.eulerAngles = new Vector3(0f, Random.value * 360, 0f);
        }

        private Vector3 GetRandomPosition()
        {
            float randomX = Random.Range(_xSize.x, _xSize.y);
            float randomZ = Random.Range(_zSize.x, _zSize.y);

            return new Vector3(randomX, 0f, randomZ);
        }
    }
}