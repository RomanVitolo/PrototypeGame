using UnityEngine;
using UnityEngine.Events;

namespace GameEventsPattern.Runtime
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] UnityEvent _unityEvent;
        [SerializeField] GameEvent _gameEvent;

        void Awake()
        {
            _gameEvent.RegisterListener(this);
        }

        public void RaiseEvent()
        {
            _unityEvent.Invoke();
        }       

        void OnDestroy()
        {
            _gameEvent.Deregister(this);
        }
    }
}
