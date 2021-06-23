using UnityEngine;

namespace Utils
{
    public class DestroyAfterTime : MonoBehaviour
    {
        public float timeToDestroy;

        void Update()
        {
            timeToDestroy -= Time.deltaTime;
            if (timeToDestroy <= 0)
                Destroy(gameObject);

        }
    }
}
