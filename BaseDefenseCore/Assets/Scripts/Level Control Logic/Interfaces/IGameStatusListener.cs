using System;

namespace LevelControlLogic
{
    public interface IGameStatusListener
    {
        public event Action OnGameStart;
        public event Action OnGameEnd;
    }
}