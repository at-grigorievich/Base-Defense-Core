using UnityEngine;

namespace BotLogic
{
    public interface IEnemyTracker
    {
        void AddEnemy(EnemyBotLogicService enemyBot);
        void RemoveEnemy(EnemyBotLogicService enemyBot);

        Vector3? FindNearby(Vector3 center, float maxDistance);
    }
}