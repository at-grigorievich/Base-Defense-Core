using System;

namespace BonusItemService
{
    public interface IBonusDroper
    {
        event Action OnDropBonus;
    }
}