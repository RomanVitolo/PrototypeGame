using System.Text;
using GameEventsPattern.Runtime;
using GameEventsPattern.Runtime.GameFlags;
using Ink.Runtime;
using QuestSystem.Scripts.Runtime;
using TMPro;
using UIHelper.Scripts.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace DialogSystem.Scripts.Runtime
{
    public class DialogController : ToggleablePanel
    {
        [SerializeField] private TextMeshProUGUI _storyText;
        [SerializeField] private Button[] _choiceButtons;
        
        Story _story;

        [ContextMenu(nameof(StartDialog))]
        public void StartDialog(TextAsset dialog)
        {
            _story = new Story(dialog.text);
            RefreshView();
            ShowCanvas();
        }

        void RefreshView()
        {
           StringBuilder storyTextBuilder = new StringBuilder();
           while (_story.canContinue)
           {
               storyTextBuilder.AppendLine(_story.Continue());
               HandleTags();
           }
           _storyText.SetText(storyTextBuilder);
           
           if(_story.currentChoices.Count == 0)
               HideCanvas();

           ShowChoiceButtons();
        }

        private void ShowChoiceButtons()
        {
            for (int i = 0; i < _choiceButtons.Length; i++)
            {
                var button = _choiceButtons[i];
                button.gameObject.SetActive(i < _story.currentChoices.Count);
                button.onClick.RemoveAllListeners();
                if (i < _story.currentChoices.Count)
                {
                    var choice = _story.currentChoices[i];
                    button.GetComponentInChildren<TextMeshProUGUI>().SetText(choice.text);
                    button.onClick.AddListener(() =>
                    {
                        _story.ChooseChoiceIndex(choice.index);
                        RefreshView();
                    });
                }
            }
        }

        void HandleTags()
        {
            foreach (var tag in _story.currentTags)
            {
                if (tag.StartsWith("E."))
                {
                    string eventName = tag.Remove(0, 2);
                    GameEvent.RaiseEvent(eventName);
                }
                else if (tag.StartsWith("Q."))
                {
                    string questName = tag.Remove(0, 2);
                    QuestController.Instance.AddQuestByName(questName);
                }
                else if (tag.StartsWith("F."))
                {
                    // #F.BrokenPanelsInspected.9
                    var values = tag.Split(".");
                    //string flagName = tag.Remove(0, 2);
                    FlagController.Instance.Set(values[1], values[2]);
                }
            }
        }
    }
}
