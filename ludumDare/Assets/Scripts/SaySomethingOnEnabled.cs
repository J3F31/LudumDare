using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaySomethingOnEnabled : MonoBehaviour
{
    public AudioClip clip;
    public float timeCounter;
    public bool enemySpawn;
    public GameObject enemy1,enemy2;
    void Start(){
        timeCounter = Time.time + 6;
        AudioSource.PlayClipAtPoint(clip,transform.position);
        

    }
    void Update(){
        if(Time.time > timeCounter &&!enemy1.activeSelf){
            timeCounter = Time.time + 15;
            enemy1.SetActive(true);
        }else if(Time.time > timeCounter &&enemy1.activeSelf){
            enemy2.SetActive(true);
            Destroy(gameObject);
        }
    }

}
