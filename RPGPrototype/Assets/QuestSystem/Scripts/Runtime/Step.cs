using System;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem.Scripts.Runtime
{
    [Serializable]
    public class Step
    {
        [field: SerializeField] public string Instructions {get; private set;}
        public List<Objective> Objectives;

        public bool HasAllObjectivesCompleted()
        {
            return Objectives.TrueForAll(t => t.IsCompleted);
        }
    }
}