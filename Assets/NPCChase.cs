
using UnityEngine; 
using UnityEngine.AI;


public class NPCChase : MonoBehaviour
{
    public Transform player; 
    public TurnOnOff lightScript; 
    private NavMeshAgent agent;

    public float minSpeed = 2.0f; 
    public float maxSpeed = 15.0f; 

    public float accelerate = 0.1f; 

    private float currentSpeed; 

    public float epsilon2 = 10.0f; 
    public float fleeDistance = 15.0f;

    private float stunTimer  = 0f; 
    private bool isStunned = false; 

    public void HitByFlashlight()
    {
        isStunned = true; 
        stunTimer = 0.3f; 
    }


    void Start()
    {

        agent = GetComponent<NavMeshAgent>(); 
        currentSpeed = minSpeed; 
        agent.speed = currentSpeed; 

    
    }


    void Update()
    {
        if(player == null)
        {
            return; 
            
        }

        if(isStunned)
        {
            agent.isStopped = true; 
            stunTimer -= Time.deltaTime; 

            if(stunTimer <= 0)
            {
                isStunned = false; 
            }
            
            return; 
            

        }
            

            if(currentSpeed < maxSpeed)
            {
                currentSpeed += accelerate * Time.deltaTime; 
                agent.speed  = currentSpeed; 
            }
        

        Collider[] hitColliders = Physics.OverlapSphere(player.position, 1.0f);
        TurnOnOff activeLight = null;



        foreach (var hit in hitColliders)
        {
            TurnOnOff light = hit.GetComponent<TurnOnOff>();
            if (light != null && light.isLightOn)
            {
                activeLight = light;
                break; 
        }

        if (activeLight != null)
        {
            float distToLight = Vector3.Distance(transform.position, activeLight.transform.position);

            if (distToLight < epsilon2)
            {
                leaveLight(activeLight.transform.position);
            }
            else
            {
                
                CheckPlayer(activeLight);
            }
        }
        else
        {
            
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        
       }   

    }


    void leaveLight(Vector3 lightPos)
    {
        Vector3 pushDir = (transform.position - lightPos).normalized;
        
        Vector3 escapeTarget = lightPos + (pushDir * (epsilon2 + fleeDistance));

        NavMeshHit hit;
        if (NavMesh.SamplePosition(escapeTarget, out hit, 3.0f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    void CheckPlayer(TurnOnOff light)
    {
        float playerDistToLight = Vector3.Distance(player.position, light.transform.position);

        if (playerDistToLight < epsilon2)
        {
            
            agent.isStopped = true; 
        }
        else
        {
           
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
    }


    


}

    