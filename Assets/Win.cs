using UnityEngine;

public class Win : MonoBehaviour
{
    private void OnEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().Win(); 
        }
    
    }


}
