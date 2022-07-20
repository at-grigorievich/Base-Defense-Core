using BotLogic.Moving;
using BotLogic.Services.Animator;
using UnityEngine;

namespace BotLogic
{
    public interface IAgent
    {
        public Vector3 CurrentPosition { get; }
        
        BotAnimatorService AnimatorService { get; }
        MovableService MovableService { get; }
    }
}