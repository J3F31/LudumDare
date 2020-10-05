using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnManager : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public Transform spawn1,spawn2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!enemy1.activeSelf){
            StartCoroutine(enemy1setactive());
        }
        if(!enemy2.activeSelf){
            StartCoroutine(enemy2setactive());
        }
    }
    IEnumerator enemy1setactive(){
        yield return new WaitForSeconds(6f);
        enemy1.GetComponent<EnemyHealth>().enemyHealth = 6;
        enemy1.SetActive(true);
        enemy1.transform.position = spawn2.position;
    }  IEnumerator enemy2setactive(){
        yield return new WaitForSeconds(6f);
        enemy2.GetComponent<EnemyHealth>().enemyHealth = 6;
        enemy2.SetActive(true);
        enemy2.transform.position = spawn2.position;
    }
}
