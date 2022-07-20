using LevelControlLogic;
using Zenject;

public class GameStatusInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var gameStatus = new GameStatus();

        Container.Bind<IGameStatusListener>().FromInstance(gameStatus).AsSingle().NonLazy();
        Container.Bind<IGameStatusHandler>().FromInstance(gameStatus).AsSingle().NonLazy();
    }
}