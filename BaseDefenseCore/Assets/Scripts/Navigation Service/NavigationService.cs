using LevelControlLogic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Navigation
{
    public class NavigationService : MonoBehaviour
    {
        [SerializeField] private NavMeshSurface[] _surfaces;

        private IGameStatusHandler _statusHandler;
        
        [Inject]
        private void Constructor(IGameStatusHandler gameStatusHandler)
        {
            _statusHandler = gameStatusHandler;
            
            foreach (var navMeshSurface in _surfaces)
            {
                navMeshSurface.BuildNavMesh();
            }
        }
    }
}