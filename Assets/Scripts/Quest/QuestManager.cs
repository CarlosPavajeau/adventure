using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] quests;

    private DialogManager manager;

    public string itemCollected;
    public string enemyKilled;

    void Start()
    {
        manager = FindObjectOfType<DialogManager>();
    }

    public bool QuestComplete(int questId)
    {
        return quests[questId].IsComplete;
    }

    public void ShowQuestText(string questText)
    {
        string[] questLines = new string[] { questText };
        manager.ShowDialog(questLines);
    }
}
