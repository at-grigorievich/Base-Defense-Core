using TMPro;
using UnityEngine;
using Zenject;

namespace BonusItemService.Zenject
{
    public class BonusContainerInstaller: MonoInstaller
    {
        [SerializeField] private TextMeshProUGUI _totalData;
        [SerializeField] private TextMeshProUGUI _currentData;

        public override void InstallBindings()
        {
            var view = new BonusContainerView(_totalData, _currentData);
            var model = new BonusContainerModel();
            var presentor = new BonusContainerPresenter(model, view);

            Container.BindInstance(presentor).AsSingle().NonLazy();
        }
    }
}