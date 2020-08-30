using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealtManager>().TakeDamage(damage);
        }
    }
}
