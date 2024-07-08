
using UnityEngine;

public class Checkpoint : MonoBehaviour
{   [SerializeField] AudioClip clickSound;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.instance.SetCheckPoint(transform.position);
            AudioSource.PlayClipAtPoint(clickSound,other.transform.position);
 
        }
    }
    
}
