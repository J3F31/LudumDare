using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopBreakerWarp : MonoBehaviour
{
    public GameObject player;
    public Camera cameraToDisable;
    public Camera cameraToEnable;
    public GameObject disableTheOldMap;
    public Transform newPosition;
    public GameObject enableTheNewMap;
    public Animator Door;
    // Start is called before the first frame update
    void OnEnable()
    {
        Door.SetBool("open",true);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= player.transform.position.y){
            cameraToDisable.gameObject.SetActive(false);
            cameraToEnable.gameObject.SetActive(true);
            player.transform.position = newPosition.position;
            disableTheOldMap.SetActive(false);
            enableTheNewMap.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
