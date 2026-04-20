
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3; 

public class TurnOnOff : MonoBehaviour
{
    public Light targetLight; 

    public NavMeshAgent agentStop; 

    public bool isLightOn; 

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

    }

    
    
}