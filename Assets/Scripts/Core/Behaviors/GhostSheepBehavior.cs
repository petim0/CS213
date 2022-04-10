using UnityEngine;

public class GhostSheepBehavior : AgentBehaviour
{    
    const string ennemiesTag1 = "Player1";
    const string ennemiesTag2 = "Player2";
    const int detectionRadius = 50;
    const int escapeRadius = 70;
    const float minGhostTimer = 5.0f;
    const float maxGhostTimer = 15.0f;
    bool isGhost = false;
    const float minSwitchBackTimer = 15.0f;
    const float maxSwitchBackTimer = 35.0f;
    
    Color colorSheep = new Color(0, 255, 0);
    AudioClip soundSheep;
    
    Color colorGhost = new Color(255, 0, 0);
    AudioClip soundGhost;
    public AudioSource myAudioSource;
    public AudioSource myAudioSheep;

    GameObject[] ennemies;

    void Start()
    {


        GameObject[] ennemies1  = GameObject.FindGameObjectsWithTag(ennemiesTag1);
        GameObject[] ennemies2 = GameObject.FindGameObjectsWithTag(ennemiesTag2);
        ennemies = new GameObject[ennemies1.Length + ennemies2.Length];
        ennemies1.CopyTo(ennemies, 0);
        ennemies2.CopyTo(ennemies, ennemies1.Length);

        //myAudioSource = GetComponent<AudioSource>();
        //myAudioSheep = GetComponent<AudioSource>();

        Debug.Log(myAudioSheep.Equals(myAudioSource));

        // myAudioSource.stop();
        Invoke("switchBehavior", Random.Range(minGhostTimer, maxGhostTimer));
        agent.SetVisualEffect(0, colorSheep, 0);   
    }


    public override Steering GetSteering()
    {

        Steering steering = new Steering();
        //implement your code here.
        Vector3 newDir = isGhost ? chaseDirection() : runAwayDirection();
        steering.linear = newDir * agent.maxAccel;
        steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear , agent.maxAccel)) ;

        return steering;
    }

    Vector3 runAwayDirection(){
        
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
            float curDistance = diff.sqrMagnitude;
            if (curDistance < escapeRadius) {
                ennemyDirection[i] = (-diff).normalized; // from go.position to position
                i +=1 ;
            }

            if (curDistance < detectionRadius)
            {
                ennemyIsClose = true;
            }
        }

        Vector3 newDir = new Vector3(0.0f, 0.0f, 0.0f);
        if (ennemyIsClose && ennemyDirection.Length > 0) {
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
        return findClosestDirection();
    }

    private void switchBehavior()
    {
        isGhost = !isGhost;

        if (isGhost) {
            // Set the led for the Ghost
            agent.SetVisualEffect(0, colorGhost, 0);
         
            myAudioSource.Play();
            
            Debug.Log("Triggered by 1");
            Invoke("switchBehavior", Random.Range(minSwitchBackTimer, maxSwitchBackTimer));

        } else {
            // Set the let for the Sheep
            agent.SetVisualEffect(0, colorSheep, 0);
            Debug.Log("Triggered by 2");

            myAudioSheep.Play();
            
            Invoke("switchBehavior", Random.Range(minSwitchBackTimer, maxSwitchBackTimer));

        }
    }

    public Vector3 findClosestDirection()
    {
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        Vector3 direction = position;
        foreach (GameObject go in ennemies)
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
        if (other.tag == ennemiesTag1 && other.tag == ennemiesTag2)
        {
            Debug.Log("Triggered by Enemy");
        }
    }


}
