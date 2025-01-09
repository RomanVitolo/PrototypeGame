using System;
using GameEventsPattern.Runtime.GameFlags;
using UnityEngine;
using UnityEngine.Serialization;

namespace QuestSystem.Scripts.Runtime
{
    [Serializable]
    public class Objective
    {
        [SerializeField] ObjectiveType _objectiveType;
        [SerializeField] private GameFlag _gameFlag;
        
        [Tooltip("This is the amount required for the count integer game flag.")]
        [SerializeField] private int _requiredValue;
        public GameFlag GameFlag => _gameFlag;

        public enum ObjectiveType
        {
            GameFlag,
            Item,
            Kill
        }

        public bool IsCompleted
        {
            get
            {
                switch (_objectiveType)
                {
                    case ObjectiveType.GameFlag:
                    {
                        if(_gameFlag is BoolGameFlag boolGameFlag)
                            return boolGameFlag.Value;
                        if(_gameFlag is IntGameFlag intGameFlag)
                            return intGameFlag.Value >= _requiredValue;
                        return false;
                    }
                    default: return false;
                }
            }
        }

        public override string ToString() 
        {
            switch (_objectiveType)
            {
                case ObjectiveType.GameFlag:
                {
                    if(_gameFlag is BoolGameFlag boolGameFlag)
                        return _gameFlag.name;
                    if (_gameFlag is IntGameFlag intGameFlag)
                        return $"{intGameFlag.name} ({intGameFlag.Value}/{_requiredValue})";
                    return "Invalid/Unknown Objective Type";
                }
                
                default: return _objectiveType.ToString();
            }
        }
    }
}