using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public void PlayFootstep()
    {
        FindObjectOfType<AudioManager>().PlaySound("Footstep");
    }

    public void PlayClimbStep()
    {
        FindObjectOfType<AudioManager>().PlaySound("ClimbStep");
    }

    public void PlayLandingSound()
    {
        FindObjectOfType<AudioManager>().PlaySound("Landing");
    }
}
