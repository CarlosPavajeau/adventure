using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class QuestItem : MonoBehaviour
{
    public int questID;
    private QuestManager manager;
    public string itemName;

    void Start()
    {
        manager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (manager.quests[questID].gameObject.activeInHierarchy &&
                !manager.QuestComplete(questID))
            {
                manager.itemCollected = itemName;
                gameObject.SetActive(false);
            }
        }
    }
}
