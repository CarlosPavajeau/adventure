using Audio;
using Creature;
using Quest;
using UnityEngine;

public class HealtManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public bool flashActive;
    public float flashLength;
    private float flashCounter;

    public int expWhenDefeated;

    public string enemyName;
    private QuestManager manager;

    private SpriteRenderer characterRendered;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        characterRendered = GetComponent<SpriteRenderer>();
        manager = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                manager.enemyKilled = enemyName;
                GameObject.Find("Player").GetComponent<CharacterStats>().AddExperience(expWhenDefeated);
            }
            else if (gameObject.CompareTag("Player"))
            {
                FindObjectOfType<SoundManager>().playerDead.Play();
            }

            gameObject.SetActive(false);
        }


        if (flashActive)
        {
            flashCounter -= Time.deltaTime;

            if (flashCounter > flashLength * 0.66f)
                ToggleColor(false);
            else if (flashCounter > flashLength * 0.33f)
                ToggleColor(true);
            else if (flashCounter > 0)
                ToggleColor(false);
            else
                ToggleColor(true);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (flashLength > 0)
        {
            flashActive = true;
            flashCounter = flashLength;
        }
    }

    private void ToggleColor(bool visible)
    {
        characterRendered.color = new Color(characterRendered.color.r, characterRendered.color.g, characterRendered.color.b, (visible) ? 1.0f : 0.0f);
    }

    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = newMaxHealth;
    }

}
