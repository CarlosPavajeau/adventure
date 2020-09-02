using UnityEngine;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour
{
    public string[] dialog;
    private DialogManager manager;
    public bool playerInTheZone;

    public GameObject infoText;
    public string textInfo;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<DialogManager>();
        infoText = Instantiate(infoText, gameObject.transform.position, Quaternion.Euler(Vector3.zero));
        infoText.GetComponentInChildren<Text>().text = textInfo;
        infoText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInTheZone = true;
            infoText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInTheZone = false;
            infoText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTheZone)
        {
            NPCMovement npcMovement = GetComponentInParent<NPCMovement>();

            if (Input.GetKey(KeyCode.E))
            {
                manager.ShowDialog(dialog);
                infoText.SetActive(false);
                if (npcMovement != null)
                    npcMovement.isTalking = true;
            }

            if (!npcMovement.isTalking)
            {
                infoText.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.7f, infoText.transform.position.z);
            }
        }
    }
}
