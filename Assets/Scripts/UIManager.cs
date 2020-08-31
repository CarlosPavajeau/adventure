using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider playerHelthBar;
    public Text playerHelthText;

    public Slider playerExperienceBar;
    public Text playerExperienceText;
    public Text playerCurrentLevelText;

    public HealtManager playerHealth;
    public CharacterStats characterStats;

    void Update()
    {
        playerHelthBar.maxValue = playerHealth.maxHelth;
        playerHelthBar.value = playerHealth.currentHelth;

        playerHelthText.text = $"HP: {playerHealth.currentHelth}/{playerHealth.maxHelth}";

        playerExperienceBar.maxValue = characterStats.expToLevelUp[characterStats.currentLevel];
        playerExperienceBar.value = characterStats.currentExp;

        playerExperienceText.text = $"EXP: {characterStats.currentExp}/{characterStats.expToLevelUp[characterStats.currentLevel]}";

        playerCurrentLevelText.text = $"Current level: {characterStats.currentLevel}";
    }
}
