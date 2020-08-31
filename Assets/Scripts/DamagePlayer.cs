using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage;

    public GameObject damageNumber;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealtManager>().TakeDamage(damage);
            GameObject clone = Instantiate(damageNumber, collision.gameObject.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().color = Color.red;
            clone.GetComponent<DamageNumber>().damagePoints = damage;
        }
    }
}
