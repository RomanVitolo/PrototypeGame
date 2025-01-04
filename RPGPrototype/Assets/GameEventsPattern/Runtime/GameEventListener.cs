using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameEventsPattern.Runtime
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent _unityEvent;
        [SerializeField] GameEvent _gameEvent;

        private void Awake()
        {
            _gameEvent.RegisterListener(this);
        }

        public void RaiseEvent()
        {
            _unityEvent?.Invoke();
        }

        private void OnDestroy()
        {
            _gameEvent.Deregister(this);
        }
    }
}