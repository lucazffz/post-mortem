using UnityEngine;
using System.Collections;

public class ToggleLight : MonoBehaviour
{
    public GameObject[] lights;
    private bool activate = false;
    public float waitTime;

    private void Start()
    {
        foreach (var light in lights) light.SetActive(false);
    }
    public void SwitchLight()
    {
        FindObjectOfType<AudioManager>().PlaySound("ButtonClick");
        

        activate = !activate;

        if (activate) StartCoroutine(wait(waitTime));
        else if (!activate) foreach (var light in lights) light.SetActive(false);
    }


    IEnumerator wait(float time)
    {
        foreach (var light in lights)
        {
            light.SetActive(true);
            FindObjectOfType<AudioManager>().PlaySound("Light");
            yield return new WaitForSeconds(time);
        } 
    }
}