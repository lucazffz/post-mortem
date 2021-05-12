using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update


    public TextMeshProUGUI[] text;

    public Animator anim;
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
        anim.SetTrigger("Play");

        yield return new WaitForSeconds(12);

        FindObjectOfType<LevelLoader>().LoadMenu();
    }
}
