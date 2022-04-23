using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorPlayer : MonoBehaviour
{
    public bool gotDiamond;

    public void DiamondCollected()
    {
        gotDiamond = true;
    }
}
