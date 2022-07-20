using System;
using ATGStateMachine;
using BotLogic.Moving;
using BotLogic.Services.Animator;
using UnityEngine;
using Zenject;

namespace BotLogic
{
    [Serializable]
    public class BotRenderer
    {
        [SerializeField] private Renderer[] _renderers;

        public void SetRendererVisible(bool enabled)
        {
            foreach (var meshRenderer in _renderers)
            {
                meshRenderer.enabled = enabled;
            }
        }
    }
    
    public class BotLogicService : StatementBehaviour<IAgent>,IAgent
    {
        [Range(0, 0.99f)] [SerializeField] protected float _smoothing;
        
        [SerializeField] private BotRenderer _botRenderer;
        
        [Inject] public BotAnimatorService AnimatorService { get; private set; }
        [Inject] public MovableService MovableService { get; private set; }

        public Vector3 CurrentPosition => transform.position;         
        
        
        private void Update() => OnExecute();

        protected void Start()
        {
            MovableService.SetMovableActive(false);
            _botRenderer.SetRendererVisible(false);
        }

        protected void InitBot()
        {
            MovableService.SetMovableActive(true);
            _botRenderer.SetRendererVisible(true);
            
            InitStartState();
            OnState();
        }
        
        public class Factory: PlaceholderFactory<UnityEngine.Object,BotLogicService> {}
    }
}