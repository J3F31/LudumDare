///
///<summary>
///Author : Federico J. Lagar
///Date : 4/10/2020 - 15:00 (UTC + 1)
///</summary>
///
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float reloadTime =2f;
    public int Ammo = 20;//needs UI
    public int maxAmmo = 20;
    public bool isReloading;
    PlayerMovement playerMovement;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    AudioSource audioSource;
    public AudioClip reloadClip;
    public Animator animator;
    public float animationTime;
    void Awake(){
        playerMovement = GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !playerMovement.isDashing &&!isReloading){
            
            Shoot();
        }
        if(Input.GetButtonDown("Reload") && !playerMovement.isDashing){
            
            Reload();
        }
    }
    void Shoot()
    {
        

        if(Ammo != 0){
        
        animator.SetBool("fire", true);
        StartCoroutine(_animationBuffer());
        
        Ammo--;
        GameObject bullet = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        rb.AddForce(firePoint.up* bulletForce,ForceMode2D.Impulse);
        }
        if(Ammo == 0){
            Reload();
        }
    }
    void Reload(){
        if(isReloading == false){
        isReloading= true;
        StartCoroutine(_Reload());
        }
    }
    IEnumerator _Reload(){
        
        yield return new WaitForSeconds(reloadTime);
        audioSource.clip = reloadClip;
        audioSource.Play();
        Ammo = maxAmmo;
        isReloading = false;
    }
    IEnumerator _animationBuffer()
    {

        yield return new WaitForSeconds(animationTime);
        animator.SetBool("fire", false);
    }
    
}
