using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject spawnzone;
    public GameObject gems;
    private float spawnTime = 120;        
    public float spawnDelay;
    public AudioClip audioSpawn;
    AudioSource aud;

    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay,spawnTime);        
    }

    void Spawn()
    {
        aud = GetComponent<AudioSource>();
        aud.PlayOneShot(audioSpawn, 0.7F);
        float x = Random.Range(spawnzone.GetComponent<BoxCollider>().bounds.min.x + 2, spawnzone.GetComponent<BoxCollider>().bounds.max.x - 2);
        float z = Random.Range(spawnzone.GetComponent<BoxCollider>().bounds.min.z + 2, spawnzone.GetComponent<BoxCollider>().bounds.max.z - 2);
        Vector3 position = new Vector3(x, 136.5f, z);
        Instantiate(gems, position, transform.rotation);
    }

} 
 


