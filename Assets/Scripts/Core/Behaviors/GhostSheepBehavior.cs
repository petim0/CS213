using UnityEngine;

public class GhostSheepBehavior : AgentBehaviour
{    
    const string ennemiesTag = "Dog";
    const int detectionRadius = 50;
    const float minGhostTimer = 5.0f;
    const float maxGhostTimer = 15.0f;
    bool isGhost = false;
    const float minSwitchBackTimer = 15.0f;
    const float maxSwitchBackTimer = 35.0f;
    
    Color colorSheep = new Color(0, 0, 255);
    AudioClip soundSheep;
    
    Color colorGhost = new Color(255, 0, 0);
    AudioClip soundGhost;
    AudioSource myAudioSource;
    AudioSource myAudioSheep;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSheep = GetComponent<AudioSource>();
        
       // myAudioSource.stop();
        Invoke("switchBehavior", Random.Range(minGhostTimer, maxGhostTimer));
        agent.SetVisualEffect(0, colorSheep, 0);
    }


    public override Steering GetSteering()
    {
        Debug.Log("Triggered by GetSteeringSheep");

        Steering steering = new Steering();
        //implement your code here.
        Vector3 newDir = isGhost ? chaseDirection() : runAwayDirection();
        steering.linear = newDir * agent.maxAccel;
        steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear , agent.maxAccel)) ;

        return steering;
    }

    Vector3 runAwayDirection(){
        Debug.Log("Triggered by RUNNAWAY");

        GameObject[] ennemies;
        ennemies = GameObject.FindGameObjectsWithTag(ennemiesTag);
        //Check to see if the tag on the collider is equal to Enemy
        bool ennemyIsClose = false;
        Vector3[] ennemyDirection = new[] { new Vector3 { x = 0, y = 0, z = 0 }, new Vector3 { x = 0, y = 0, z = 0} };
        int i = 0;
        foreach (GameObject ennemy in ennemies)
        {

            //Get distance
            Vector3 diff = new Vector3(0.0f, 0.0f, 0.0f);
            diff.x = ennemy.transform.position.x - this.transform.position.x;
            diff.z = ennemy.transform.position.z - this.transform.position.z;

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
                newDir.x= newDir.x+dir.x;
                newDir.z= newDir.z+dir.z;
            }
            newDir = newDir.normalized;
        }
        return newDir;
    }

    Vector3 chaseDirection(){
        Debug.Log("Triggered by ChaseDirection");
        return findClosestDirection(ennemiesTag);
    }

    private void switchBehavior()
    {
        isGhost = !isGhost;

        if (isGhost) {
            // Set the led for the Ghost
            agent.SetVisualEffect(0, colorGhost, 0);
            // Stop sheep sound
            myAudioSource.Stop();

            // Play ghost sound
            myAudioSource.clip = soundGhost;
            myAudioSource.Play();
            myAudioSheep.Stop();
            Debug.Log("Triggered by 1");
            Invoke("switchBehavior", Random.Range(minSwitchBackTimer, maxSwitchBackTimer));

        } else {
            // Set the let for the Sheep
            agent.SetVisualEffect(0, colorSheep, 0);
            Debug.Log("Triggered by 2");

            // Stop ghost sound
            myAudioSheep.Stop();

            // Play sheep sound
            myAudioSource.clip = soundSheep;
           // myAudioSheep.PlayOneShot(soundSheep, 1.0f);
            myAudioSource.Play();
            myAudioSheep.Stop();
            Invoke("switchBehavior", Random.Range(minSwitchBackTimer, maxSwitchBackTimer));

        }
    }

    public Vector3 findClosestDirection(string tag)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        Vector3 direction = position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
                direction = diff.normalized;
            }
        }
        return direction;
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
