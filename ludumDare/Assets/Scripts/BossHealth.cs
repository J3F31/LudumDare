using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "bullet")
        {
            currentHealth -= 10;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
