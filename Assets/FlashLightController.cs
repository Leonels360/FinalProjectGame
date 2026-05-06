using UnityEngine;

public class FlashLightController : MonoBehaviour
{
    public GameObject flashlightBeam; 
    public float maxBattery = 10f; 

    private float currentBattery; 
    private bool hasFlashLight = false; 
    private bool isDrained = false; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentBattery = maxBattery; 

        if(flashlightBeam != null)
            flashlightBeam.SetActive(false); 
        
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
        }
        else
        {
            flashlightBeam.SetActive(false); 
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
