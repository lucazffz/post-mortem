using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    public GameObject[] lights;
    private bool activate = false;

    private void Start()
    {
        foreach (var light in lights) light.SetActive(false);
    }
    public void SwitchLight()
    {
        FindObjectOfType<AudioManager>().PlaySound("ButtonClick");

        activate = !activate;

        foreach (var light in lights)
        {
            if (activate) light.SetActive(true);
            else light.SetActive(false);
        }
    }
}