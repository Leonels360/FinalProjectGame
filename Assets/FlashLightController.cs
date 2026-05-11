using UnityEditor;
using UnityEngine;

public class FlashLightController : MonoBehaviour
{
    public GameObject flashlightBeam; 
    public float maxBattery = 10f; 

    public Transform camTransform; 

    public float flashRange = 10f; 

    private float currentBattery; 
    private bool hasFlashLight = false; 
    private bool isDrained = false; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentBattery = maxBattery; 

        if(flashlightBeam != null)
            flashlightBeam.SetActive(false); 
        

        if(camTransform == null)
        {
            camTransform = Camera.main.transform; 
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasFlashLight || isDrained)
            return; 

        if(Input.GetKey(KeyCode.X))
        {
            flashlightBeam.SetActive(true); 
            RunBattery(); 
            FlashLightRay(); 
        }
        else
        {
            flashlightBeam.SetActive(false); 
        }
        
    }

    void FlashLightRay()
    {
        RaycastHit hit; 

        if(Physics.Raycast(camTransform.position, camTransform.forward, out hit,flashRange))
        {
            NPCChase npc = hit.collider.GetComponent<NPCChase>(); 
            if(npc != null)
            {
                npc.HitByFlashlight(); 
            }
        }
    }

    void RunBattery()
    {
        currentBattery -= Time.deltaTime; 

        if(currentBattery <= 0)
        {
            currentBattery = 0; 
            isDrained = true; 
            flashlightBeam.SetActive(false); 
            Debug.Log("flashlight battery is dead."); 


        }
    }

    public void ObtainFlashLight()
    {
        hasFlashLight = true; 
        Debug.Log("Player is using flashlgiht."); 
    }
}
