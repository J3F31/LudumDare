using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCloseDoor : MonoBehaviour
{
    public GameObject nextToActive;
    public GameObject cameraToDisable, cameraToEnable;
    public Animator door;
    public AudioClip clipToPlay;
    public bool ifNeedsToPlayClip;
    public bool destroyOnFinish;
    public bool openDoor;
    public bool cameraDisabler;
    public bool neverDestroy;
    GameObject Player;
    void Start(){
        Player = GameObject.Find("Marine");
    }
    void OnEnable(){
        if(ifNeedsToPlayClip){
            AudioSource.PlayClipAtPoint(clipToPlay,transform.position);
        }
    }
    void Update(){
        
        if(Player.transform.position.y > transform.position.y){
           
            door.SetBool("open",openDoor);
            if(cameraDisabler){
            cameraToDisable.SetActive(false);
            cameraToEnable.SetActive(true);
            }
            if(destroyOnFinish){
             nextToActive.SetActive(true);
            Destroy(gameObject);}
            else if(!destroyOnFinish && !neverDestroy){
             nextToActive.SetActive(true);
            gameObject.SetActive(false);            
        }else{
            nextToActive.SetActive(true);
        }}

    }

    
}
