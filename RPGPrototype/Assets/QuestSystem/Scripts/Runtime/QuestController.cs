using System;
using System.Collections.Generic;
using System.Linq;
using GameEventsPattern.Runtime.GameFlags;
using UnityEngine;

namespace QuestSystem.Scripts.Runtime
{
    public class QuestController : MonoBehaviour
    {
        public static QuestController Instance {get; private set;}
        
        [SerializeField] QuestPanel _questPanel;
        [SerializeField] List<Quest> _allQuests = new List<Quest>();
        
        List<Quest> _activeQuests = new List<Quest>();

        private void Awake() => Instance = this;

        public void AddQuest(Quest quest)
        {
            _activeQuests.Add(quest);
            _questPanel.SelectQuest(quest);
        }

        public void AddQuestByName(string questName)
        {
            var quest = _allQuests.FirstOrDefault(t => t.name == questName);
            if(quest != null) AddQuest(quest);
            else 
                Debug.Log($"Missing quest: {questName}");
        }
    }
}