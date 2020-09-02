using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questID;
    private QuestManager manager;

    public string startText, completeText;
    public int experienceOnComplete;

    public bool needsItem;
    public string itemNeeded;

    public bool needsEnemy;
    public string enemyName;
    public int numberOfEnemies;
    private int enemiesKilled;

    public bool needsOtherQuest;
    public int requireQuest;

    private CharacterStats playerStats;

    public bool IsComplete { get; private set; }

    void Update()
    {
        if (needsItem && manager.itemCollected == itemNeeded)
        {
            manager.itemCollected = null;
            CompleteQuest();
        }
        else if (needsEnemy && manager.enemyKilled == enemyName)
        {
            manager.enemyKilled = null;
            ++enemiesKilled;
            if (enemiesKilled >= numberOfEnemies)
                CompleteQuest();
        }
    }

    public void StartQuest()
    {
        if (manager is null)
            manager = FindObjectOfType<QuestManager>();

        if (needsOtherQuest)
            if (!manager.quests[requireQuest].IsComplete)
                return;

        playerStats = GameObject.Find("Player").GetComponent<CharacterStats>();
        manager.ShowQuestText(startText);
    }

    public void CompleteQuest()
    {
        if (playerStats != null)
            playerStats.AddExperience(experienceOnComplete);

        manager.ShowQuestText(completeText);
        IsComplete = true;
        gameObject.SetActive(false);
    }
}
