using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{
    public string newPlaceName = "New place here";

    public string goToPlaceName;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                FindObjectOfType<PlayerController>().nextPlaceName = goToPlaceName;
                SceneManager.LoadScene(newPlaceName);
            }
        }
    }
}
