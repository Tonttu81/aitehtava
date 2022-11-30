using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public Image heart;
    public Image heart1;
    public Image heart2;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            Destroy(heart2);
        }

        if (currentHealth == 2)
        {
            Destroy(heart);
        }

        if (currentHealth == 1)
        {
            Destroy(heart1.gameObject);
        }
    }
}
