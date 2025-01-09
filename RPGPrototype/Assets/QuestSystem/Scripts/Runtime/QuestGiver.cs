using UnityEngine;

namespace QuestSystem.Scripts.Runtime
{
    public class QuestGiver : MonoBehaviour
    {
        [SerializeField] Quest _quest;

        void OnTriggerEnter(Collider other)
        {
            QuestController.Instance.AddQuest(_quest);
            /*if (other.CompareTag("Player"))
            {
            }*/
        }
    }
}