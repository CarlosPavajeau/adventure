using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{
    public string newPlaceName = "New place here";

    public string goToPlaceName;

    InfoText infoText;

    private void Start()
    {
        infoText = GetComponent<InfoText>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            if (infoText != null)
                infoText.showText = true;
    }

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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            if (infoText != null)
                infoText.showText = false;
    }
}
