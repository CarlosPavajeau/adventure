using UnityEngine;

namespace Creature
{
    public class CharacterStats : MonoBehaviour
    {
        public int currentLevel;
        public int currentExp;
        public int[] expToLevelUp;

        public int[] hpLevels;
        public int[] strengthLevels;
        public int[] defenseLevels;

        private HealtManager healthManager;

        // Start is called before the first frame update
        void Start()
        {
            healthManager = GetComponent<HealtManager>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (currentLevel >= expToLevelUp.Length)
                return;

            if (currentExp >= expToLevelUp[currentLevel])
            {
                currentExp = 0;
                ++currentLevel;

                healthManager.UpdateMaxHealth(hpLevels[currentLevel]);
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
            return strengthLevels[currentLevel];
        }
    }
}
