using Player;
using UnityEngine;

namespace Utils
{
    public class SpawnZone : MonoBehaviour
    {
        private PlayerController player;
        private CameraFollow playerCamera;

        public Vector2 facingDirection = Vector2.zero;
        public string placeName;

        void Start()
        {
            player = FindObjectOfType<PlayerController>();
            playerCamera = FindObjectOfType<CameraFollow>();

            if (player.nextPlaceName != placeName)
                return;


            player.transform.position = transform.position;
            playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y, playerCamera.transform.position.z);

            player.lastMovement = facingDirection;
        }
    }
}
