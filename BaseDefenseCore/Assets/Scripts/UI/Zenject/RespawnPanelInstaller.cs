using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Zenject
{
    public class RespawnPanelInstaller: MonoInstaller
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Button _button;
        
        public override void InstallBindings()
        {
            CallbackPanel rPanel = new CallbackPanel(_canvas, _button);

            Container.BindInstance(rPanel).WithId("Respawn-Panel").AsSingle();
        }
    }
}