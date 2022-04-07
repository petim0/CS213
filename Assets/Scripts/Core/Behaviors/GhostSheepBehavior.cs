using UnityEngine;

public class GhostSheepBehavior : AgentBehaviour
{    
    const string ennemiesTag = "Dog";
    const int detectionRadius = 50;

    public override Steering GetSteering()
    {
        
        Steering steering = new Steering();
        //implement your code here.
        GameObject[] ennemies;
        ennemies = GameObject.FindGameObjectsWithTag(ennemiesTag);
        //Check to see if the tag on the collider is equal to Enemy
        bool ennemyIsClose = false;
        Vector3[] ennemyDirection;
        int i = 0;
        foreach (GameObject ennemy in ennemies)
        {

            //Get distance
            Vector3 diff = ennemy.transform.position - this.transform.position;

            // Get direction from A to B
            ennemyDirection[i] = (-diff).normalized; // from go.position to position
            i +=1 ;

            float curDistance = diff.sqrMagnitude;
            if (curDistance < detectionRadius)
            {
                ennemyIsClose = true;
            }
        }

        Vector3 newDir = new Vector3(0.0f, 0.0f, 0.0f);
        if (ennemyIsClose) {
            foreach (Vector3 dir in ennemyDirection)
            {
                newDir = newDir + dir;
            }
            newDir = newDir.normalized;
        }

        return steering;
    }


    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == ennemiesTag)
        {
            Debug.Log("Triggered by Enemy");
        }
    }


}
