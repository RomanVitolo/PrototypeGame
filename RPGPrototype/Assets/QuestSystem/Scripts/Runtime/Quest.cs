using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace QuestSystem.Scripts.Runtime
{
    [CreateAssetMenu(fileName = "Quest", menuName = "QuestSystem/Quest")]
    public class Quest : ScriptableObject
    {
        public event Action Changed;
        [field: SerializeField] public string DisplayName { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite QuestSprite { get; private set; }
        public Step CurrentStep => Steps[currentStepIndex];

        [Tooltip("Designer/Programmer Notes")]
        [SerializeField] string _notes;
        
        public List<Step> Steps;
        private Step GetCurrentStep() => Steps[currentStepIndex];
        
        int currentStepIndex;

        private void OnEnable()
        {
            currentStepIndex = 0;
            foreach (var step in Steps)
            foreach (var objective in step.Objectives)
            {
                if (objective.GameFlag != null)
                    objective.GameFlag.Changed += HandleFlagChanged;
            }
        }

        private void HandleFlagChanged()
        {
            TryProgress();
            Changed?.Invoke();
        }

        public void TryProgress()
        {
            var currentStep = GetCurrentStep();
            if (currentStep.HasAllObjectivesCompleted())
            {
                currentStepIndex++;
                Changed?.Invoke();
                //Do Whatever we do when a quest progress like update the UI
            }
        }
    }
}