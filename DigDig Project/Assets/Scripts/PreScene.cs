using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreScene : MonoBehaviour
{
    // Start is called before the first frame update


    public TextMeshProUGUI[] text;
    void Start()
    {
       

        
        StartCoroutine(Wait());

       
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);

        foreach (var item in text)
        {
            item.enabled = true;
        }
        GetComponent<Animator>().SetTrigger("Play");

        yield return new WaitForSeconds(12);

        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }
}
