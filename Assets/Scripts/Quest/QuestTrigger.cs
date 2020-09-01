using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class QuestTrigger : MonoBehaviour
{
    private QuestManager manager;
    public int questID;

    public bool startPoint, endpoint;

    void Start()
    {
        manager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!manager.questCompleted[questID])
            {
                if (startPoint && !manager.quests[questID].gameObject.activeInHierarchy)
                {
                    manager.quests[questID].gameObject.SetActive(true);
                    manager.quests[questID].StartQuest();
                }
                else if (endpoint && manager.quests[questID].gameObject.activeInHierarchy)
                {
                    manager.quests[questID].CompleteQuest();
                }
            }
        }
    }
}
