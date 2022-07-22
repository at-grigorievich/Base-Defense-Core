namespace BonusItemService
{
    public class BonusContainerPresenter
    {
        private readonly BonusContainerModel _model;
        private readonly BonusContainerView _view;

        public BonusContainerPresenter(BonusContainerModel model, BonusContainerView view)
        {
            _view = view;
            _model = model;
            
            UpdateCurrentView();
            UpdateTotalView();
        }

        public void AddCurrentCount()
        {
            _model.AddCurrentCount();
            UpdateCurrentView();
        }

        public void UpdateTotalCount()
        {
            _model.UpdateTotalCount();
            UpdateTotalView();
            UpdateCurrentView();
        }

        public void ClearCurrentCount()
        {
            _model.ClearCurrentCount();
            UpdateCurrentView();
        }
        
        private void UpdateTotalView() => _view.UpdateTotalData(_model.TotalCount);
        private void UpdateCurrentView() => _view.UpdateCurrentData(_model.CurrentCount);
    }
}