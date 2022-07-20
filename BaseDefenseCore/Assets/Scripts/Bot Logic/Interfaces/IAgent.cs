using BotLogic.Moving;
using BotLogic.Services.Animator;

namespace BotLogic
{
    public interface IAgent
    {
        BotAnimatorService AnimatorService { get; }
        MovableService MovableService { get; }
    }
}