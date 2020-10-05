using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warpLogic : MonoBehaviour
{
    public GameObject doorController;
    public GameObject player;
    public GameObject warpBreaker;
    public Transform warpTarget;
    // Start is called before the first frame update
    void OnEnable()
    {
        warpBreaker.SetActive(false);
        player.transform.position = warpTarget.position;
        doorController.SetActive(true);
        gameObject.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
