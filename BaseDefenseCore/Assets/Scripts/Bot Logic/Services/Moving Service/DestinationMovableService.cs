using UnityEngine;
using UnityEngine.AI;

namespace BotLogic.Moving
{
    public class DestinationMovableService: MovableService
    {
        private readonly NavMeshAgent _navAgent;
        
        public DestinationMovableService(NavMeshAgent navAgent)
        {
            _navAgent = navAgent;
        }

        public override void SetMovableActive(bool enabled) => _navAgent.enabled = enabled;
        

        public override void Move(Vector3 direction)
        {
            _navAgent.SetDestination(direction);
        }

        public override void Rotate(Vector3 direction, float smoothTime)
        {
            _navAgent.updateRotation = true;
        }
    }
}