using Zenject;

namespace BotLogic.Zenject
{
    public class BotFactoryInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindFactory<UnityEngine.Object, BotLogicService, BotLogicService.Factory>()
                .FromFactory<PrefabFactory<BotLogicService>>()
                .NonLazy();
        }
    }
}