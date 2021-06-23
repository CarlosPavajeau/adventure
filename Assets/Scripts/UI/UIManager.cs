using Creature;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
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
            playerHelthBar.maxValue = playerHealth.maxHealth;
            playerHelthBar.value = playerHealth.currentHealth;

            playerHelthText.text = $"HP: {playerHealth.currentHealth}/{playerHealth.maxHealth}";

            playerExperienceBar.maxValue = characterStats.expToLevelUp[characterStats.currentLevel];
            playerExperienceBar.value = characterStats.currentExp;

            playerExperienceText.text = $"EXP: {characterStats.currentExp}/{characterStats.expToLevelUp[characterStats.currentLevel]}";

            playerCurrentLevelText.text = $"Current level: {characterStats.currentLevel}";
        }
    }
}
