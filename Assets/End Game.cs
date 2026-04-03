using UnityEngine;

public class EndGame : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().EndGame(false); 
        }
    }

}
