using UnityEngine;
using UnityEngine.AI;

namespace BotLogic.Moving
{
    public class NavMovableService: MovableService
    {
        private readonly NavMeshAgent _navAgent;
        
        public NavMovableService(NavMeshAgent navAgent)
        {
            _navAgent = navAgent;
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
            if (isNeedRotate)
            {
                agent.rotation = Quaternion.Lerp(agent.rotation,
                    Quaternion.LookRotation(direction),smoothTime);
            }
        }
    }
}