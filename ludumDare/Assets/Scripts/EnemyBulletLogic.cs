using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletLogic : MonoBehaviour
{
    public GameObject player;
    private Vector3 direction;
    public float speed;
    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Marine");
        direction = (player.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += direction * speed * Time.fixedDeltaTime;
    }
    void OnCollisionEnter2D(Collision2D col){
        Instantiate(hitEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
