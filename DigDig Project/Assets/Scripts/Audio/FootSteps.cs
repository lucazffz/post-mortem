using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public void PlayFootstep()
    {
        FindObjectOfType<AudioManager>().PlaySound("Footstep");
    }
}
