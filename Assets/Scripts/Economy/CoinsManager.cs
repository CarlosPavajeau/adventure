using UnityEngine;
using UnityEngine.UI;

namespace Economy
{
    public class CoinsManager : MonoBehaviour
    {
        public Text moneyText;
        public int currentGold;

        private const string GoldKey = "CurrentGold";

        // Start is called before the first frame update
        void Start()
        {
            if (PlayerPrefs.HasKey(GoldKey))
            {
                currentGold = PlayerPrefs.GetInt(GoldKey);
            }
            else
            {
                currentGold = 0;
                PlayerPrefs.SetInt(GoldKey, 0);
            }

            moneyText.text = currentGold.ToString();
        }

        public void AddMoney(int moneyCollected)
        {
            currentGold += moneyCollected;
            PlayerPrefs.SetInt(GoldKey, currentGold);
            moneyText.text = currentGold.ToString();
        }
    }
}
