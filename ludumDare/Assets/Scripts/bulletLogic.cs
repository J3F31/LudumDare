using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletLogic : MonoBehaviour
{
    public GameObject hitEffect;
    AudioSource audioSource;
    public AudioClip hitClip;
    public float bulletDuration = 2f;
    void Start(){
        StartCoroutine(_DESTROY());
    }
    void OnCollisionEnter2D(Collision2D collision){
        
        
        Instantiate(hitEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
        
        
    }
    IEnumerator _DESTROY(){
       yield return new WaitForSeconds(bulletDuration);
        Destroy(gameObject);
                //Instantiate(hitEffect,transform.position,Quaternion.identity);

    }
}
