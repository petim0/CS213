using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorGem : MonoBehaviour
{

   public GameObject gameobject;

   private void OnTriggerEnter(Collider other)
    {
        CollectorPlayer collectorPlayer = other.GetComponent<CollectorPlayer>();

        if(collectorPlayer != null)
        {
            collectorPlayer.DiamondCollected();
            gameObject.SetActive(false);
        }
    }
}
