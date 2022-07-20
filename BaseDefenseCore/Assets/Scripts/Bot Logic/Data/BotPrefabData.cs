using System;
using UnityEngine;

namespace BotLogic.Data
{
    public enum BotType
    {
        PlayerBot,
        EnemyBot
    }
    
    [CreateAssetMenu(fileName = "Bots data", menuName = "Bots/ New Bots data", order = 0)]
    public class BotPrefabData : ScriptableObject
    {
        [SerializeField] private BotLogicService _playerBotPrefab;
        [SerializeField] private BotLogicService _enemyBotPrefab;

        public BotLogicService GetBot(BotType botType)
        {
            return botType switch
            {
                BotType.PlayerBot => _playerBotPrefab,
                BotType.EnemyBot => _enemyBotPrefab,
                _ => throw new ArgumentException("Cant find this type")
            };
        }
    }
}