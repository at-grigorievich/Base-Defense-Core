using System;
using ATGStateMachine;
using BotLogic.Moving;
using BotLogic.Services.Animator;
using FightService;
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
        
        [Inject] public AttackService AttackService { get; private set; }
        
        public Vector3 CurrentPosition => transform.position;         
        
        protected void Start()
        {
            _botRenderer.SetRendererVisible(false);
            
            MovableService.SetMovableActive(false);
        }
        protected void Update()
        {
            OnExecute();
            
            AttackService.UpdateReloading();
        }

        protected void InitBot()
        {
            _botRenderer.SetRendererVisible(true);
            
            MovableService.SetMovableActive(true);
            
            AttackService.OnAttack += AnimatorService.AnimateAttack;
            
            InitStartState();
            OnState();
        }
        
        //Animator Event
        public virtual void OnAttackEnd() => AttackService.EndAttack();


        public class Factory: PlaceholderFactory<UnityEngine.Object,BotLogicService> {}
    }
}