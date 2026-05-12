using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightController : MonoBehaviour
{   
    public GameObject flashlightIcon;//to add ui icon of flashlight
    public GameObject flashlightBeam; 
    public float maxBattery = 10f; 

    public Transform camTransform; 

    public float flashRange = 10f; 

    private float currentBattery; 
    private bool hasFlashLight = false; 
    private bool isDrained = false;

    public Slider batterySlider;
    public GameObject batteryUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentBattery = maxBattery;
        //turns off icon by default
        if (flashlightIcon != null)
        {
            flashlightIcon.SetActive(false);
        }

        if (batteryUI != null)
        {
            batteryUI.SetActive(false);
        }

        if (batterySlider != null)
        {
            batterySlider.maxValue = maxBattery;
            batterySlider.value = currentBattery;
        }

        if (flashlightBeam != null)
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
            if (batteryUI != null)
            {
                batteryUI.SetActive(true);
            }
            RunBattery(); 
            FlashLightRay(); 
        }
        else
        {
            flashlightBeam.SetActive(false);

            if (batteryUI != null)
            {
                batteryUI.SetActive(false);
            }
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

        if (batterySlider != null)
        {
            batterySlider.value = currentBattery;
        }

        if (currentBattery <= 0)
        {
            currentBattery = 0; 
            isDrained = true; 
            flashlightBeam.SetActive(false); 
            if (flashlightIcon != null)//hide icon when battery is dead
            {
                flashlightIcon.SetActive(false);
            }
            Debug.Log("flashlight battery is dead."); 


            


        }
    }

    public void ObtainFlashLight()
    {
        hasFlashLight = true; 
        //activates icon
        if (flashlightIcon != null)
            flashlightIcon.SetActive(true);

        Debug.Log("Player is using flashlgiht."); 
    }
}
