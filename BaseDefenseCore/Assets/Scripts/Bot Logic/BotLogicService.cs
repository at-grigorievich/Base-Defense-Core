using System;
using ATGStateMachine;
using BotLogic.Moving;
using BotLogic.Services.Animator;
using FightService;
using LifecycleService;
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
    
    public class BotLogicService : StatementBehaviour<IAgent>,IAgent,IDamageable
    {
        [Range(0, 0.99f)] [SerializeField] protected float _smoothing;
        
        [SerializeField] private BotRenderer _botRenderer;
        
        [Inject] public BotAnimatorService AnimatorService { get; private set; }
        [Inject] public MovableService MovableService { get; private set; }
        [Inject] protected AttackService AttackService { get; private set; }
        [Inject] protected HealthService HealthService { get; private set; }
       
        public Vector3 CurrentPosition => transform.position;         
        
        public event EventHandler<Vector3> OnDieInPlace;
        
        
        protected void Start()
        {
            gameObject.SetActive(false);
            MovableService.SetMovableActive(false);
        }
        protected void Update()
        {
            OnExecute();
            AttackService.UpdateReloading();
        }

        public void InitBot()
        {
            gameObject.SetActive(true);
            MovableService.SetMovableActive(true);
            ResetHealth();
            
            AttackService.OnAttack += AnimatorService.AnimateAttack;
            
            InitStartState();
            OnState();
        }
        protected virtual void DieBot()
        {
            gameObject.SetActive(false);
            MovableService.SetMovableActive(false);
            
            AttackService.OnAttack -= AnimatorService.AnimateAttack;
            
            OnDieInPlace?.Invoke(this,transform.position);
        }

        #region IDamageable implementation
        public void ResetHealth() => HealthService.ResetHealth();
        public void TakeDamage(int damageCount)
        {
            HealthService.RemoveHealth(damageCount);
            if (HealthService.IsHealthEnd)
            {
                DieBot();
            }
        }
        #endregion
        
        // Animator Event
        public virtual void OnAttackEnd() => AttackService.EndAttack();

        public class Factory: PlaceholderFactory<UnityEngine.Object,BotLogicService> {}
    }
}