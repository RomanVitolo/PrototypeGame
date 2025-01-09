using System.Linq;
using System.Text;
using TMPro;
using UIHelper.Scripts.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace QuestSystem.Scripts.Runtime
{
    public class QuestPanel : ToggleablePanel
    {
        [SerializeField] Quest _selectedQuest;
        [SerializeField] TextMeshProUGUI _nameText;
        [SerializeField] TextMeshProUGUI _descriptionText;
        [SerializeField] TextMeshProUGUI _currentObjectiveText;
        [SerializeField] Image _iconImage;
         Step _selectedStep => _selectedQuest.CurrentStep;
        
        [ContextMenu(nameof(Bind))]
        public void Bind()
        {
            _iconImage.sprite = _selectedQuest.QuestSprite;
            _nameText.SetText(_selectedQuest.DisplayName);
            _descriptionText.SetText(_selectedQuest.Description);

            DisplayStepInstructionsAndObjectives();
        }

        void DisplayStepInstructionsAndObjectives()
        {
            StringBuilder builder = new StringBuilder();
            if (_selectedStep != null)
            {
                builder.AppendLine(_selectedStep.Instructions);
                foreach (var objective in _selectedStep.Objectives)
                {
                    string rgb = objective.IsCompleted ? "green" : "red";
                    builder.AppendLine($"<color={rgb}>{objective}</color>");
                }
            }

            _currentObjectiveText.SetText(builder.ToString());
        }

        public void SelectQuest(Quest quest)
        {
            if(_selectedQuest)
                _selectedQuest.Changed -= DisplayStepInstructionsAndObjectives;
            
            _selectedQuest = quest;
            Bind();
            ShowCanvas();

            _selectedQuest.Changed += DisplayStepInstructionsAndObjectives;
        }
    }
}