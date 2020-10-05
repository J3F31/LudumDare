using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarineHealthManager : MonoBehaviour
{
    public static bool dieable;
    public GameObject trapEnemy;
    public GameObject portal;
    public float MaxHealth = 100;//needs ui
    public float Health = 100;//needs UI
    // Start is called before the first frame update
    void Start()
    {
        dieable=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Health>MaxHealth){
            Health = MaxHealth;
        }
        if(Health <= 0){
            if(dieable){
                portal.SetActive(true);
                trapEnemy.SetActive(false);
                Health= 100;
                dieable=false;
            }else{
                SceneManager.LoadScene(1);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag =="medpack15"){
            Health += 15;
            Destroy(col.gameObject);
            
        }
        if(col.gameObject.tag =="medpack25"){
            Health += 25;
            Destroy(col.gameObject);
            
        }
        if(col.gameObject.tag =="medpack50"){
            Health += 50;
            Destroy(col.gameObject);
            
        }
        if(col.gameObject.tag =="medpack75"){
            Health += 100;
            Destroy(col.gameObject);
            
        }
        if(col.gameObject.tag =="portal"){
            SceneManager.LoadScene(2);
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "enemyBullet")
        {
            Health -= 5;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "bossBullet")
        {
            Health -= 5;
            collision.gameObject.SetActive(false);
        }
    }
}
