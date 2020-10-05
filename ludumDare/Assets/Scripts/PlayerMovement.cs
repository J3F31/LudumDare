///
///<summary>
///Author : Federico J. Lagar
///Date : 4/10/2020 - 12:20 (UTC + 1)
///</summary>
///
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 mPosition;// Mouse Position
    [SerializeField]
    [Range(0,8)]
    public float dashCooldown = 2f;//needs UI
    float Angle;
    [SerializeField]
    [Range(0,20)]
    float Speed = 5f,dashLength= 5f,dashSpeed;
    public bool isMoving,isDashing,dashOnCooldown,coroutineStarted;
    AudioSource audioSource;
    public AudioClip dashClip;
    Vector3 dashDirection;
    Vector3 direction;
    public Animator animator;
    void Start(){
        audioSource =GetComponent<AudioSource>();
        coroutineStarted = true;
        dashOnCooldown = false;
    }
    void Update()
    {      
       checkDirection();
       lookAtMousePosition();
       if(Input.GetButtonDown("Dash") && !dashOnCooldown){
          audioSource.clip = dashClip;
          audioSource.Play(); 
          isDashing=true;
          coroutineStarted = false;
          dashOnCooldown=true;
          dashDirection = mPosition.normalized;
          StartCoroutine(DashCooldown());
       }
       
    }
    void FixedUpdate(){
        transform.rotation = Quaternion.Euler(new Vector3(0,0,Angle-90));
        Dash();
        move();
    }
    void move()
    {
        if(isMoving && !isDashing)
        transform.position += direction * Speed * Time.fixedDeltaTime; 
    }
    void checkDirection(){
         if(Input.GetAxisRaw("Vertical") > 0){
         direction = (direction + Vector3.up - Vector3.down).normalized; isMoving = true;
       }
       if(Input.GetAxisRaw("Vertical") < 0){
         direction = (direction + Vector3.down - Vector3.up).normalized; isMoving = true;
       }
       if(Input.GetAxisRaw("Horizontal") > 0){
         direction = (direction + Vector3.right - Vector3.left).normalized; isMoving = true;
       }
       if(Input.GetAxisRaw("Horizontal") < 0){
         direction = (direction + Vector3.left - Vector3.right).normalized; isMoving = true;
       }
       if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
       isMoving = false;
    }
    void lookAtMousePosition()
    {
        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mPosition = mPosition - transform.position;
        mPosition.z = 1;
        Angle = Mathf.Atan2(mPosition.y , mPosition.x) * Mathf.Rad2Deg;
    }
   
    void Dash(){
        if(!coroutineStarted){
            coroutineStarted = true;

             StartCoroutine(DashDuration());
        }
        if(isDashing)
        {
            animator.SetBool("dash", true);
            StartCoroutine(_dashAnimation());

            transform.position += dashDirection * dashSpeed * Time.fixedDeltaTime;
        }
    }
    IEnumerator DashCooldown(){
        yield return new WaitForSeconds(dashCooldown);
        dashOnCooldown = false;

    }
    IEnumerator DashDuration(){
        yield return new WaitForSeconds(dashLength);
        isDashing = false;
        
    }

    IEnumerator _dashAnimation()
    {
        yield return new WaitForSeconds(dashLength);
        animator.SetBool("dash", false);
    }

      
}
