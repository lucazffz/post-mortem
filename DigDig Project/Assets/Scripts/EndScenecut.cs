using System.Collections;
using UnityEngine;

public class EndScenecut : MonoBehaviour
{
    public GameObject cover;
    public GameObject jumpScare;

    public static bool playingCutscene;

    private void Start()
    {
        cover.SetActive(false);
        jumpScare.SetActive(false);
        playingCutscene = false;
    }

    public void StartSceneCut()
    {
        StartCoroutine(Timer());
        playingCutscene = true;
    }

    IEnumerator Timer()
    {

       

        yield return new WaitForSeconds(2);

        FindObjectOfType<AudioManager>().PlaySound("ButtonClick");
        FindObjectOfType<AudioManager>().PlaySound("Light");

        cover.SetActive(true);

        yield return new WaitForSeconds(2);
        FindObjectOfType<AudioManager>().PlaySound("Scream");
        jumpScare.SetActive(true);

        yield return new WaitForSeconds(0.2f);
        jumpScare.SetActive(false);

        yield return new WaitForSeconds(2);
        FindObjectOfType<LevelLoader>().LoadNextLevel();







    }
    
}
