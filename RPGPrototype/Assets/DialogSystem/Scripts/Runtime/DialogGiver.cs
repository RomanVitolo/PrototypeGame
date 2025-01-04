using System;
using Core.Runtime;
using UnityEngine;

namespace DialogSystem.Scripts.Runtime
{
    public class DialogGiver : MonoBehaviour
    {
        [SerializeField] private TextAsset _dialog;
        
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<ThirdPersonMovement>();
            if (player is not null)
            {
                FindAnyObjectByType<DialogController>().StartDialog(_dialog);
                transform.LookAt(player.transform);
            }

            
        }
    }
}
