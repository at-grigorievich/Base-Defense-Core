namespace BonusItemService
{
    public class BonusContainerModel
    {
        public int TotalCount { get; private set; }
        public int CurrentCount { get; private set; }

        public void UpdateTotalCount()
        {
            TotalCount += CurrentCount;
            ClearCurrentCount();
        }

        public void ClearCurrentCount() => CurrentCount = 0;
        
        public void AddCurrentCount() => CurrentCount++;
    }
}