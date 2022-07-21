using UnityEngine;

namespace BotLogic
{
    public interface ITargetable
    {
        bool IsTargetAvailable { get; }
        
        Vector3 TargetPosition { get; }

        void SetTargetAvailable(bool isAvailable);
    }
}