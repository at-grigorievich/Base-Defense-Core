using TMPro;

namespace BonusItemService
{
    public class BonusContainerView
    {
        private readonly TextMeshProUGUI _totalData;
        private readonly TextMeshProUGUI _currentData;

        public BonusContainerView(TextMeshProUGUI tData,TextMeshProUGUI cData)
        {
            _currentData = cData;
            _totalData = tData;
        }

        public void UpdateTotalData(int value)
        {
            _totalData.SetText(value.ToString());
        }

        public void UpdateCurrentData(int value)
        {
            string info = $"+{value}";
            _currentData.SetText(info);
        }
    }
}