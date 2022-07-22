using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CallbackPanel
    {
        private readonly Canvas _canvas;
        private readonly Button _callbackButton;

        private Action _onClick;
        
        public CallbackPanel(Canvas canvas,Button button)
        {
            _canvas = canvas;
            _callbackButton = button;
            
            _callbackButton.onClick.AddListener(OnCallback);
            _canvas.enabled = false;
        }

        public void ShowPanel()
        {
            _canvas.enabled = true;
        }
        
        public void AddCallback(Action callback)
        {
            _onClick += callback;
        }
        
        private void OnCallback()
        {
            _onClick?.Invoke();

            _canvas.enabled = false;
        }
    }
}