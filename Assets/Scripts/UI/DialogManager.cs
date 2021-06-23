using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DialogManager : MonoBehaviour
    {
        public GameObject dialogBox;
        public Text dialogText;
        public bool dialogActive;

        public string[] dialogLines;
        public int currentDialogLine;

        void Update()
        {
            if (dialogActive && Input.GetKeyDown(KeyCode.Space))
                ++currentDialogLine;

            if (currentDialogLine >= dialogLines.Length)
            {
                dialogActive = false;
                dialogBox.SetActive(false);
                currentDialogLine = 0;
            }
            else
            {
                dialogText.text = dialogLines[currentDialogLine];
            }

        }

        public void ShowDialog(string[] dialogs)
        {
            dialogActive = true;
            dialogBox.SetActive(true);
            dialogLines = dialogs;
        }
    }
}
