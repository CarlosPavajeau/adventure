using Quest;
using UI;
using UnityEngine;

namespace GameObjects
{
    [RequireComponent(typeof(Collider2D))]
    public class GameObjectController : MonoBehaviour
    {
        public bool startQuest;
        public int questID;

        private QuestManager questManager;
        private InfoText infoText;

        private bool playerCanInteract;

        // Start is called before the first frame update
        void Start()
        {
            questManager = FindObjectOfType<QuestManager>();
            infoText = GetComponent<InfoText>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerCanInteract = true;
                if (infoText != null)
                    infoText.showText = true;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (playerCanInteract && Input.GetKey(KeyCode.E))
            {
                if (startQuest && !questManager.QuestComplete(questID))
                {
                    questManager.quests[questID].gameObject.SetActive(true);
                    questManager.quests[questID].StartQuest();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (infoText != null)
                infoText.showText = false;
        }

    }
}
