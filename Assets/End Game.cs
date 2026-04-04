using UnityEngine;

public class EndGame : MonoBehaviour
{
    //private void OnCollisionEnter(Collision collision)
    private void OnTriggerEnter(Collider other)
    {
        //if(collision.gameObject.CompareTag("Player"))
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().EndGame(false); 
        }
    }

}
