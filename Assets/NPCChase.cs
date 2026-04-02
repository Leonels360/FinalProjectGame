using UnityEngine;
using UnityEngine.AI;

public class NPCChase : MonoBehaviour
{
    public Transform player; 
    private NavMeshAgent agent;

    void Start()
    {

        agent = GetComponent<NavMeshAgent>(); 

    
    }


    void Update()
    {
        if(player != null)
        {
            //give Unity a coordinate and it will move the capsule for me
            agent.SetDestination(player.position); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //need to make a game over. 
            //using scene manager 
            FindObjectOfType<GameManager>().GameOver();
        }
        
    }
}
