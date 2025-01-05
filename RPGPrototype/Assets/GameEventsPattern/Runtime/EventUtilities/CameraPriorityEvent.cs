using Unity.Cinemachine;
using UnityEngine;

namespace GameEventsPattern.Runtime.EventUtilities
{
    public class CameraPriorityEvent : MonoBehaviour
    {
        [field: SerializeField] public CinemachineCamera CameraComponent {get; private set;}
        
        public void AssignCameraPriority(int priority)
        {
            CameraComponent.Priority = priority;
        }
    }
}

