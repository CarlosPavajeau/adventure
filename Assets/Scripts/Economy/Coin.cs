using UnityEngine;

namespace Economy
{
    public class Coin : MonoBehaviour
    {
        public int value;
        private CoinsManager manager;

        // Start is called before the first frame update
        void Start()
        {
            manager = FindObjectOfType<CoinsManager>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                manager.AddMoney(value);
                Destroy(gameObject);
            }
        }
    }
}
