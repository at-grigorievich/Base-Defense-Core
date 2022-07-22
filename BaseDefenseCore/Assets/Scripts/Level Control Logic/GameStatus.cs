using System;
using LevelControlLogic;

public class GameStatus: IGameStatusHandler,IGameStatusListener
{
    public event Action OnGameStart;
    public event Action OnGameEnd;
    
    public void DoStartGame() => OnGameStart?.Invoke(); 
    public void DoEndGame() => OnGameEnd?.Invoke();
}
