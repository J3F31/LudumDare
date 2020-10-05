using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitSpawn : MonoBehaviour
{
    public GameObject _medkit;
    
    public float spawnRate;
    private Vector3 pos;
    private float randomX;
    

    void Start()
    {
        InvokeRepeating("Spawn", 0f, spawnRate);
    }

    void Spawn()
    {
        randomX = Random.Range(-16f, 32f);
        pos = new Vector3(randomX, -4f, 0f);
        Instantiate(_medkit, pos, Quaternion.identity);
    }
}
