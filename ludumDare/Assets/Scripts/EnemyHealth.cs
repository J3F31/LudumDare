using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;
    public bool notDestroyable;
    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            enemyHealth --;
            if(enemyHealth == 0)
            {
               Kill(); 
            }
            
        }
    }
    
    void Kill()
    {

       GameRoomManager.killCount++;
       if(notDestroyable)
       gameObject.SetActive(false);
       else
       Destroy(gameObject);

    }
}
