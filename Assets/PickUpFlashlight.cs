using UnityEngine;

public class PickUpFlashlight : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player"))
        {
            FlashLightController controller = other.GetComponent<FlashLightController>(); 

            if(controller != null)
            {
                controller.ObtainFlashLight(); 
                Destroy(gameObject); 
            }
        }
    }

}
