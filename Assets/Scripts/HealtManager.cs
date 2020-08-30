using UnityEngine;

public class HealtManager : MonoBehaviour
{
    public int maxHelth;
    public int currentHelth;

    // Start is called before the first frame update
    void Start()
    {
        currentHelth = maxHelth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHelth <= 0)
            gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHelth -= damage;
    }

    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHelth = newMaxHealth;
        currentHelth = newMaxHealth;
    }

}
