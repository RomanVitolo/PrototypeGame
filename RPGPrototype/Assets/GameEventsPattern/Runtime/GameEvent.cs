using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEventsPattern.Runtime
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Game Events/Game Event")]
    public class GameEvent : SerializedScriptableObject
    {
        static HashSet<GameEvent> _listenedEvents = new HashSet<GameEvent>();
        
        HashSet<GameEventListener> _gameEventListeners = new HashSet<GameEventListener>();

        public void RegisterListener(GameEventListener listener)
        {
            _gameEventListeners.Add(listener);
            _listenedEvents.Add(this);
        }

        public void Deregister(GameEventListener listener)
        {
            _gameEventListeners.Remove(listener);
            if(_gameEventListeners.Count == 0)
                _listenedEvents.Remove(this);
        } 

        [ContextMenu(nameof(InvokeCurrentEvent))]
        public void InvokeCurrentEvent()
        {
            foreach (var gameEventListener in _gameEventListeners)
            {
                gameEventListener.RaiseEvent();
            }
        }

        public static void RaiseEvent(string eventName)
        {
            foreach (var gameEvent in _listenedEvents)
            {
                if(gameEvent.name == eventName)
                    gameEvent.InvokeCurrentEvent();
            }
        }
    }
}
