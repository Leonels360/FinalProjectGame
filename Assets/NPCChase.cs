using UnityEngine;
using UnityEngine.AI;

public class NPCChase : MonoBehaviour
{
    public Transform player; 
    public TurnOnOff lightScript; 
    private NavMeshAgent agent;

    void Start()
    {

        agent = GetComponent<NavMeshAgent>(); 

    
    }


    void Update()
    {
        if(player != null && lightScript != null)
        {
            //give Unity a coordinate and it will move the capsule for me
            if(!(lightScript.isLightOn && Vector3.Distance(transform.position, player.position) < 5.0f)) 
            {
                agent.SetDestination(player.position); 

            }
        }
    }



}

    