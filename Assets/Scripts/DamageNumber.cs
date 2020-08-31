using UnityEngine;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour
{
    public float damageSpeed;
    public float damagePoints;

    public Text damageText;
    public Color color = Color.white;

    void Update()
    {
        damageText.color = color;
        damageText.text = $"-{damagePoints}";
        transform.position = new Vector3(transform.position.x, transform.position.y + damageSpeed, transform.position.z);
    }
}
