using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTrigger : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other){


        if (other.transform.parent.gameObject.CompareTag("Player1"))
        {
            PersistentManagerScript.Instance.player1Score++;

        } else if (other.transform.parent.gameObject.CompareTag("Player2")) {

            PersistentManagerScript.Instance.player2Score++;
        }
        
        Debug.Log(other.transform.parent.gameObject.tag + " triggers.");
    }
}
