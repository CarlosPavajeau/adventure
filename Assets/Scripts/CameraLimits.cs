using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CameraLimits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<CameraFollow>().ChangeLimits(GetComponent<BoxCollider2D>());
    }
}
