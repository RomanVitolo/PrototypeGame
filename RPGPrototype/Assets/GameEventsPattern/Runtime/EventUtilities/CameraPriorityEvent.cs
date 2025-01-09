using Sirenix.OdinInspector;
using Unity.Cinemachine;
using UnityEngine;

namespace GameEventsPattern.Runtime.EventUtilities
{
    public class CameraPriorityEvent : SerializedMonoBehaviour
    {
        [field: SerializeField, TabGroup("Assign Camera Component"), GUIColor("#FFB9C5")] 
        public CinemachineCamera CameraComponent {get; private set;}
        
        public void AssignCameraPriority(int priority)
        {
            CameraComponent.Priority = priority;
        }
    }
}

