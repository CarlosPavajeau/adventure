using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;
    public int[] expToLevelUp;

    public int[] hpLevels, strenghtLevels, defenseLevels;

    private HealtManager healtManager;

    // Start is called before the first frame update
    void Start()
    {
        healtManager = GetComponent<HealtManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel >= expToLevelUp.Length)
            return;

        if (currentExp >= expToLevelUp[currentLevel])
        {
            currentExp = 0;
            ++currentLevel;

            healtManager.UpdateMaxHealth(hpLevels[currentLevel]);
        }
    }

    public void AddExperience(int exp)
    {
        currentExp += exp;
    }

    public int GetCurrentDefense()
    {
        return defenseLevels[currentLevel];
    }

    public int GetCurrentStrenght()
    {
        return strenghtLevels[currentLevel];
    }
}
