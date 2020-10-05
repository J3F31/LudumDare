using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
   	public GameObject Boss;
    private Vector2 moveDirection;
    private float moveSpeed;
    public GameObject hitEffect;    
    
    private void OnEnable()
    {
        Physics2D.IgnoreCollision(GameObject.Find("bullet").GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Invoke("Destroy", 3f);
    }
    void Start()
    {
        moveSpeed = 5f;
    }
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        Instantiate(hitEffect,transform.position,Quaternion.identity);
        gameObject.SetActive(false);
    }

}
