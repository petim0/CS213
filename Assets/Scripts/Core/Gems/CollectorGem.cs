using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorGem : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Collider>() == CollideWith)
        {
            CollideWith.SendMessage(OnTriggerEnterMessage, SendMessageOptions.DontRequireReceiver);
            if (SendToSelf == true)
            {
                this.SendMessage(MessageToSelf, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    void Update()
    {
        OnTriggerEnter(player);
    }
}
