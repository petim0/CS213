using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject spawnzone;
    public GameObject[] gems;
    public float spawnTime = 50f;        
    public float spawnDelay = 3f;
    public AudioClip audioSpawn;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);        
    }

    void Spawn()
    {
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(audioSpawn, 0.7F);
        int gemIndex = Random.Range(0, gems.Length);
        float x = Random.Range(spawnzone.GetComponent<BoxCollider>().bounds.min.x + 2, spawnzone.GetComponent<BoxCollider>().bounds.max.x - 2);
        float z = Random.Range(spawnzone.GetComponent<BoxCollider>().bounds.min.z + 2, spawnzone.GetComponent<BoxCollider>().bounds.max.z - 2);
        Vector3 position = new Vector3(x, 136.5f, z);
        Instantiate(gems[gemIndex], position , transform.rotation);
    }

    // Update is called once per frame 
    void Update()
    {
    }
} 
 


