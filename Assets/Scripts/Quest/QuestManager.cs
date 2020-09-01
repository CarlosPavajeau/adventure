using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] quests;
    public bool[] questCompleted;

    private DialogManager manager;

    public string itemCollected;

    public string enemyKilled;

    // Start is called before the first frame update
    void Start()
    {
        questCompleted = new bool[quests.Length];
        manager = FindObjectOfType<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowQuestText(string questText)
    {
        string[] questLines = new string[] { questText };
        manager.ShowDialog(questLines);
    }
}
