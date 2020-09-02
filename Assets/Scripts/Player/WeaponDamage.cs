using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damage;
    public GameObject hurtAnimation;
    public GameObject hitPoint;
    public GameObject damageNumber;

    private CharacterStats characterStats;

    private void Start()
    {
        characterStats = GetComponentInParent<CharacterStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            int totalDamage = damage;
            if (characterStats != null)
                totalDamage += characterStats.GetCurrentStrenght();
            collision.gameObject.GetComponent<HealtManager>().TakeDamage(totalDamage);

            Instantiate(hurtAnimation, hitPoint.transform.position, hitPoint.transform.rotation);
            GameObject clone = Instantiate(damageNumber, hitPoint.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;
        }
    }
}
