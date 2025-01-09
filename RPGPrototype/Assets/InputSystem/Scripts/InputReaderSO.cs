using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem.GlobalInputs.Scripts
{
    
    [CreateAssetMenu(fileName = "InputReader", menuName = "InputSystem/InputReaderSO")]
    public class InputReaderSO : ScriptableObject, Inputs.IPlayerActions
    {
        public Vector2 MovementValue { get; private set; } = Vector3.zero;
        public Vector2 AimInputValue { get; private set; }
        
        private Inputs _controls;
    
        public void InitializeControls()
        {
            _controls = new Inputs();
            _controls.Player.SetCallbacks(this);   
            _controls.Player.Enable();
        }    
    
        public void DestroyControls() => _controls.Player.Disable();
        
        public void OnMove(InputAction.CallbackContext context)
        {
            MovementValue = context.ReadValue<Vector2>();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            AimInputValue = context.ReadValue<Vector2>();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
           Debug.Log("Pep");
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            Debug.Log("Pep");
        }

        public void OnCrouch(InputAction.CallbackContext context)
        {
            Debug.Log("Pep");
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            Debug.Log("Pep");
        }

        public void OnPrevious(InputAction.CallbackContext context)
        {
            Debug.Log("Pep");
        }

        public void OnNext(InputAction.CallbackContext context)
        {
            Debug.Log("Pep");
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            Debug.Log("Pep");
        }
    }
}
