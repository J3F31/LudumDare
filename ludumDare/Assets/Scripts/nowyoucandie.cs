using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nowyoucandie : MonoBehaviour
{
    public AudioClip clip;
    public GameObject enemiesToSpawn;
    void OnEnable(){
        AudioSource.PlayClipAtPoint(clip,transform.position);
        StartCoroutine(spawnTrap());
    }
    IEnumerator spawnTrap(){
        yield return new WaitForSeconds(13f);
        MarineHealthManager.dieable = true;
        enemiesToSpawn.SetActive(true);

    }
}
