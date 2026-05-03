

using UnityEngine;
using UnityEngine.AI;

public class SpawnFlashlightScript : MonoBehaviour
{
    public GameObject flashlightPrefab; 
    public float range = 50.0f;  

    void Start()
    {
        SpawnFlashlight(); 
    }

    void SpawnFlashlight()
    {
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * range; 



        NavMeshHit hit; 

        if(NavMesh.SamplePosition(randomPoint, out hit, range, 1))
        {
            Instantiate(flashlightPrefab, hit.position, Quaternion.identity);
        }


    }

    
}
