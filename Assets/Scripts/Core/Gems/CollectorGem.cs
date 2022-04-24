using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorGem : MonoBehaviour
{
    public GameObject gameobject;
    //CollectorPlayer player1;
    CollectorPlayer player2;
    public AudioClip audioCollected;
    AudioSource aud;

    /*private void Awake()
    {
        player1 = gameObject.GameObject.Find("Player1").GetComponent<CollectorPlayer>();
        player2 = gameObject.GameObject.Find("Player2").GetComponent<CollectorPlayer>();
    }*/

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.transform.tag.CompareTo("Player1") == 1)
        {
            
            gameObject.SetActive(false);
            aud = GetComponent<AudioSource>();
            aud.PlayOneShot(audioCollected, 0.7F);
            //player1.DiamondCollected();

        }
        else if(other.gameObject.transform.tag.CompareTo("Player2") == 1)
        {
            gameObject.SetActive(false);
            aud = GetComponent<AudioSource>();
            aud.PlayOneShot(audioCollected, 0.7F);
            //player2.DiamondCollected();


        }
    }
}
