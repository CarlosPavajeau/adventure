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

    private CharacterStats playerStats;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (needsItem && manager.itemCollected.Equals(itemNeeded))
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
        manager = FindObjectOfType<QuestManager>();
        playerStats = GameObject.Find("Player").GetComponent<CharacterStats>();
        manager.ShowQuestText(startText);
    }

    public void CompleteQuest()
    {
        if (playerStats != null)
            playerStats.AddExperience(experienceOnComplete);

        manager.ShowQuestText(completeText);
        manager.questCompleted[questID] = true;
        gameObject.SetActive(false);
    }
}
