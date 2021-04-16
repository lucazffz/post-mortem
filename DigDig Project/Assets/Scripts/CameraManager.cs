using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject vCam;

    public CapsuleCollider2D playerCollider;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger && other == playerCollider) vCam.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player") && !other.isTrigger && other == playerCollider) vCam.SetActive(false);
    }
}
