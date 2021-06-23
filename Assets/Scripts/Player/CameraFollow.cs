using UnityEngine;

namespace Player
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private GameObject followTarget;
        [SerializeField]
        private Vector3 targetPosition;
        [SerializeField]
        private float cameraSpeed = 4.0f;

        private Camera mainCamera;
        private BoxCollider2D cameraLimits;

        private Vector3 minLimits, maxLimits;

        private float halfWidth, halfHeight;
        private void Start()
        {
            cameraLimits = GameObject.Find("CameraLimits").GetComponent<BoxCollider2D>();
            ChangeLimits(cameraLimits);
        }

        void Update()
        {
            targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSpeed);

            float clampX = Mathf.Clamp(transform.position.x, minLimits.x + halfWidth, maxLimits.x - halfWidth);
            float clampY = Mathf.Clamp(transform.position.y, minLimits.y + halfHeight, maxLimits.y - halfHeight);

            transform.position = new Vector3(clampX, clampY, transform.position.z);
        }

        public void ChangeLimits(BoxCollider2D cameraLimits)
        {
            minLimits = cameraLimits.bounds.min;
            maxLimits = cameraLimits.bounds.max;

            mainCamera = GetComponent<Camera>();

            halfWidth = mainCamera.orthographicSize;
            halfHeight = halfWidth / Screen.width * Screen.height;
        }
    }
}
