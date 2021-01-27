using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject vCam;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger) vCam.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player") && !other.isTrigger) vCam.SetActive(false);
    }
}
