using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoomManager : MonoBehaviour
{
    public Animator door;
    public static int killCount;
    public AudioSource audioSource;
    public GameObject enemy1,enemy2;
    public Transform spawn1,spawn2;
    public bool setnextobjectactive;
    public bool disableGameObjectOnEnable;
    public GameObject objectToDisableOnEnable;
    public GameObject nextObject;
    public bool roomLoop; 
    public bool destroyOnComplete;
    public bool doesntOpenDoor;
    public bool trap;
    public int killCountNeeded;
    // Start is called before the first frame update
    void Awake()
    {
        if(!doesntOpenDoor){
        killCount= 0;
        door.SetBool("open",false);
    }}
    void OnEnable() {
        if(disableGameObjectOnEnable)
        objectToDisableOnEnable.SetActive(false);
if(roomLoop){
            enemy1.transform.position = spawn1.position;
            enemy2.transform.position = spawn2.position;
            enemy1.GetComponent<EnemyHealth>().enemyHealth = 5;
            enemy2.GetComponent<EnemyHealth>().enemyHealth = 5;
            enemy1.SetActive(true);
            enemy2.SetActive(true);
        }
    }
    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(killCount == killCountNeeded){
            killCount = 0;
            if(setnextobjectactive){
                nextObject.SetActive(true);
            }
            if(trap){
                MarineHealthManager.dieable = false;
            }
            if(!doesntOpenDoor)
            openDoor();
            if(destroyOnComplete){
                Destroy(gameObject);
            }else{
                gameObject.SetActive(false);
            }
        }
        
    }
    void openDoor(){
        door.SetBool("open",true);
    }

}
