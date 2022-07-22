using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BotLogic.Data
{
    public class EnemyTrackerService: IEnemyTracker
    {
        private HashSet<EnemyBotLogicService> _enemies = 
            new HashSet<EnemyBotLogicService>();

        public void AddEnemy(EnemyBotLogicService enemyBot)
        {
            _enemies.Add(enemyBot);
        }

        public void RemoveEnemy(EnemyBotLogicService enemyBot)
        {
            _enemies.Remove(enemyBot);
        }

        public Vector3? FindNearby(Vector3 center, float maxDistance)
        {
            if (_enemies.Count == 0)
                return null;
            
            var arr = _enemies.ToArray();
            
            var s = arr.Select(t => new
            {
                obj = t.CurrentPosition,
                dist = Vector3.Distance(center, t.CurrentPosition)
            }).Aggregate((o1, o2) => o1.dist < o2.dist ? o1 : o2);

            return s.dist <= maxDistance ? s.obj : null;
        }

        public void ClearAll() => _enemies.Clear();
    }
}