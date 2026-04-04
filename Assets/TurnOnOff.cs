using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3; 

public class TurnOnOff : MonoBehaviour
{
    public Light targetLight; 

    public NavMeshAgent agentStop; 

    public bool isLightOn; 

    private bool playerNear = false; 
    private float timer; 

    //void start() -orginal way it was
    void Start()
    {
        timer = Random.Range(3.0f, 7.0f); 
    }
    

    void Update()
    {
        timer -= Time.deltaTime; 

        if (timer <= 0)
        {
            isLightOn = !isLightOn; 

            targetLight.enabled = isLightOn; 
            timer = Random.Range(3.0f, 7.0f);   
        }


         if(playerNear && isLightOn)
            {
                agentStop.isStopped = true; //-not sure if necessary

                Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position; 

                Vector3 goDirection = (transform.position - playerPos).normalized; 

                Vector3 goToPath = transform.position + (goDirection * 5.0f); 

                agentStop.isStopped = false; 
                agentStop.SetDestination(goToPath); 
            }
            else
            {
                agentStop.isStopped = false; 
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerNear = true; 
        }
    }

    private void OnTriggerExit(Collider other)  //was OnTriggExit, wrong
    {
        if(other.CompareTag("Player"))
        {
            playerNear = false; 
        }
    }
}