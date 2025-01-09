using UnityEngine;
using UnityEngine.Serialization;

namespace GameEventsPattern.Runtime.GameFlags
{
    public class GameFlagTriggerArea : MonoBehaviour
    {
        [SerializeField] private BoolGameFlag _boolGameFlag;

        private void OnTriggerEnter(Collider other) => _boolGameFlag.Set(true);
    }
}