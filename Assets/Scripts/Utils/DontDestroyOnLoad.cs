using Player;
using UnityEngine;

namespace Utils
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        void Start()
        {
            if (!PlayerController.playerCreated)
            {
                DontDestroyOnLoad(transform.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
