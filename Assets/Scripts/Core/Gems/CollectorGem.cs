using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorGem : MonoBehaviour
{
    CollectorPlayer player1;
    CollectorPlayer player2;
    public AudioSource aud;



    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.transform.tag.CompareTo("Player1") == 1)
        {
            player1 = other.gameObject.GetComponentInParent<CollectorPlayer>(); 
            aud.Play();
            gameObject.SetActive(false);
            player1.DiamondCollected();

        }
        else if(other.gameObject.transform.tag.CompareTo("Player2") == 1)
        {
            other.gameObject.GetComponentInParent<CollectorPlayer>().DiamondCollected(); ;
            aud.Play();
            gameObject.SetActive(false);


        }
    }
}
