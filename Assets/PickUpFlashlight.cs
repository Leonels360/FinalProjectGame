using UnityEngine;

public class PickUpFlashlight : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {

        Debug.Log("Flashlight touched by: " + other.name + " with tag: " + other.tag);
        if(other.CompareTag("Player"))
        {
            Debug.Log("Picked up flashlight"); 

            Destroy(gameObject);
        }
    }

}
