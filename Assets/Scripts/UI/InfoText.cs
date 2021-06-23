using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InfoText : MonoBehaviour
    {
        public GameObject infoText;
        public string textInfo;

        public bool showText;

        public float yDiff = 0.7f;

        private void Start()
        {
            infoText = Instantiate(infoText, gameObject.transform.position, Quaternion.Euler(Vector3.zero));
            infoText.GetComponentInChildren<Text>().text = textInfo;
            infoText.SetActive(false);
        }

        private void Update()
        {
            if (showText)
            {
                if (!infoText.activeInHierarchy)
                    infoText.SetActive(true);
                infoText.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + yDiff, infoText.transform.position.z);
            }
            else
            {
                if (infoText.activeInHierarchy)
                    infoText.SetActive(false);
            }
        }
    }
}
