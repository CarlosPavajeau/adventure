using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public string[] dialog;
    private DialogManager manager;
    private bool playerInTheZone;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<DialogManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            playerInTheZone = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            playerInTheZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTheZone && Input.GetKey(KeyCode.E))
        {
            manager.ShowDialog(dialog);

            NPCMovement npcMovement = GetComponentInParent<NPCMovement>();
            if (npcMovement != null)
                npcMovement.talking = true;
        }
    }
}
