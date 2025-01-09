using UnityEngine;

namespace GameEventsPattern.Runtime.GameFlags
{
    [CreateAssetMenu(fileName = "Bool Game Flag", menuName = "Game Events/Game Flags/Bool Game Flag")]
    public class BoolGameFlag : GameFlag<bool>
    {
        public void Set(bool value)
        {
            Value = value;
            SendChanged();
        }
    }
}
