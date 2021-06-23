using UI;
using UnityEngine;

namespace NPC
{
    public class NpcDialog : MonoBehaviour
    {
        public string[] dialog;
        private DialogManager manager;
        private InfoText infoText;

        public bool playerInTheZone;

        // Start is called before the first frame update
        void Start()
        {
            manager = FindObjectOfType<DialogManager>();
            infoText = GetComponent<InfoText>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerInTheZone = true;
                if (infoText != null)
                    infoText.showText = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerInTheZone = false;
                if (infoText != null)
                    infoText.showText = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (playerInTheZone)
            {
                NpcMovement npcMovement = GetComponentInParent<NpcMovement>();

                if (Input.GetKey(KeyCode.E))
                {
                    manager.ShowDialog(dialog);
                    if (npcMovement != null)
                        npcMovement.isTalking = true;
                }

                if (npcMovement.isTalking)
                    if (infoText != null)
                        infoText.showText = true;
            }
        }
    }
}
