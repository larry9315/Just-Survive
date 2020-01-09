using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;
    int currentHealth;
    public GameObject deathAnimation;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            GameObject obj = (GameObject)Instantiate(deathAnimation, transform.position, Quaternion.identity);
            Destroy(obj, 5f);
            Destroy(gameObject);
        }
    }

    public void HurtPlayer(int damageAmount)
    {
        currentHealth -= damageAmount;
    }
}
