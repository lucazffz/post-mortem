using UnityEngine;
using System.Collections;


public class FlickerLight : MonoBehaviour
{
    float radius;

   

    void Start()
    {
        StartCoroutine(changeRadius());
    }

    

   
    void Update()
    {
        GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().pointLightOuterRadius = radius;
    }

    IEnumerator changeRadius()
    {
       float rnd = Random.Range(4.3f, 5f);

        radius = rnd;

        rnd = Random.Range(0.07f, 0.13f);
        yield return new WaitForSeconds(rnd);

        StartCoroutine(changeRadius());
    }
}
