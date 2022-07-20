using LevelControlLogic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Navigation
{
    public class NavigationService : MonoBehaviour
    {
        [SerializeField] private NavMeshSurface[] _surfaces;

        [Inject]
        private void Constructor(IGameStatusHandler gameStatusHandler)
        {
            foreach (var navMeshSurface in _surfaces)
            {
                navMeshSurface.BuildNavMesh();
            }
            
            gameStatusHandler.DoStartGame();
        }
    }
}