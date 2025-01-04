using System.Text;
using GameEventsPattern.Runtime;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogSystem.Scripts.Runtime
{
    public class DialogController : MonoBehaviour
    {
        
        [SerializeField] private TextMeshProUGUI _storyText;
        [SerializeField] private Button[] _choiceButtons;

        [SerializeField] private GameObject _gameObject;
        
        private Story _story;

        [ContextMenu(nameof(StartDialog))]
        public void StartDialog(TextAsset dialog)
        {
            _story = new Story(dialog.text);
            RefreshView();
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
                Debug.Log(tag);
                if (tag.StartsWith("E."))
                {
                    string eventName = tag.Remove(0, 2);
                    GameEvent.RaiseEvent(eventName);
                }
            }
        }
    }
}
