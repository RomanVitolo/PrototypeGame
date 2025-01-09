using UnityEngine;

namespace GameEventsPattern.Runtime.GameFlags
{
    [CreateAssetMenu(fileName = "Counted int Game Flag", menuName = "Game Events/Game Flags/Counted int Game Flag")]
    public class IntGameFlag : GameFlag<int>
    {
        public void Modify(int value)
        {
            Value += value;
            SendChanged();
        }

        public void Set(int value)
        {
            Value = value;
            SendChanged();
        }
    }
    
    public class StringGameFlag : GameFlag<string>
    {
        public void Modify(string value)
        {
            Value = value;
            SendChanged();
        }
    }
    
    public class DecimalGameFlag : GameFlag<decimal>
    {
        public void Modify(decimal value)
        {
            Value = value;
            SendChanged();
        }
    }
}