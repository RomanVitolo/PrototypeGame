using UnityEngine;

namespace Core.Runtime
{
    public class LookAtCamera : MonoBehaviour
    {
        
        void LateUpdate()
        {
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180f, 0f);
        }
    }
}
