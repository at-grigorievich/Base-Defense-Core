using UnityEngine;
using Zenject;

namespace UI
{
    public class RespawnHelperButton : MonoBehaviour
    {
        [Inject(Id = "Respawn-Panel")] private CallbackPanel _panel;
        public void Show() => _panel.ShowPanel();
    }
}