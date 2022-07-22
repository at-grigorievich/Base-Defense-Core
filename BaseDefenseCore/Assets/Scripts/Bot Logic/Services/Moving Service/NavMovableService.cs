using UnityEngine;
using UnityEngine.AI;

namespace BotLogic.Moving
{
    public class NavMovableService: MovableService
    {
        private readonly NavMeshAgent _navAgent;
        private readonly IEnemyTracker _tracker;

        private readonly float _maxDistance;
        private readonly float _autoRotateSpeed;

        private readonly float _agentDefaultSpeed;
        
        public NavMovableService(NavMeshAgent navAgent, IEnemyTracker tracker,
            float maxDistance, float autoRotateSpeed)
        {
            _navAgent = navAgent;
            _tracker = tracker;

            _maxDistance = maxDistance;
            _autoRotateSpeed = autoRotateSpeed;

            _agentDefaultSpeed = _navAgent.speed;
        }

        public override void SetMovableActive(bool enabled)
        {
            _navAgent.enabled = enabled;
        }
        

        public override void Move(Vector3 direction)
        {
            Vector3 resDirection = direction * _navAgent.speed * Time.deltaTime;
            _navAgent.Move(resDirection);
        }
        
        public override void Rotate(Vector3 direction, float smoothTime)
        {
            bool isNeedRotate = Vector3.Distance(direction, Vector3.zero) >= Mathf.Epsilon;

            Transform agent = _navAgent.transform;
            
            var nearby =  _tracker.FindNearby(agent.position,_maxDistance);
            if (nearby != null)
            {
                LerpLookRotation(nearby.Value,agent);
                _navAgent.speed = _agentDefaultSpeed / 1.5f;
                
                return;
            }
            
            _navAgent.speed = _agentDefaultSpeed;
            if (isNeedRotate)
            {
                agent.rotation = Quaternion.Lerp(agent.rotation,
                    Quaternion.LookRotation(direction),smoothTime);
            }
        }

        private void LerpLookRotation(Vector3 target, Transform agent)
        {
            var targetDirection = target - agent.position;
            targetDirection.y = agent.position.y;

            var targetRot = Quaternion.LookRotation(targetDirection);

            agent.rotation = Quaternion.Lerp(agent.rotation, targetRot, 
                _autoRotateSpeed * Time.deltaTime);
        }
    }
}