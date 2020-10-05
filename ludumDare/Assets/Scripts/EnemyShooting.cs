using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 2f;
    private float _fireRate;
    public float fireDistance;
    float Angle;
    Vector3 playerPos;
    void Update()
    {
        _fireRate -= Time.deltaTime; 

        if(Vector2.Distance(transform.position, player.position) <= fireDistance && _fireRate < 0f)
        {
            
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            _fireRate = fireRate;
            animator.SetBool("fire",true);
        }
        if(Vector2.Distance(transform.position, player.position) <= fireDistance)
        {
            animator.SetBool("walk", false);
        } else
        {
            animator.SetBool("fire",false);
            animator.SetBool("walk",true);
        }
        
    }
    void FixedUpdate(){
        playerPos = player.position;
        playerPos = playerPos - transform.position;
        playerPos.z = 1;
        Angle = Mathf.Atan2(playerPos.y , playerPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,Angle-90));
    }
   
}
