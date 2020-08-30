using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HealtManager>().TakeDamage(damage);
        }
    }
}
