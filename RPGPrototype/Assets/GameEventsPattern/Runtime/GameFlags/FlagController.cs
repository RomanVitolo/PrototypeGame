using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameEventsPattern.Runtime.GameFlags
{
    public class FlagController : MonoBehaviour
    {
        [SerializeField] List<GameFlag> _allFlags;
        Dictionary<string, GameFlag> flagsByName;
        public static FlagController Instance {get; private set;}
        void Awake() => Instance = this;

        private void Start() => flagsByName = _allFlags.ToDictionary(k
            => k.name.Replace(" ",  ""), v => v);

        public void Set(string flagName, string value)
        {
            if (flagsByName.TryGetValue(flagName, out var flag) == false)
            {
                Debug.LogError($"Flag {flagName} not found");
                return;
            }
            
            if (flag is IntGameFlag intGameFlag)
            {
                if(int.TryParse(value, out int intGameValue))
                    intGameFlag.Set(intGameValue);
            }
            
        }
    }
}