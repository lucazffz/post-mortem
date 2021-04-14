using System.Collections;
using UnityEngine;

public class EndScenecut : MonoBehaviour
{
    public GameObject cover;

    static public bool playingCutscene;

    private void Start()
    {
        cover.SetActive(false);
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
        cover.SetActive(true);

        yield return new WaitForSeconds(1);

        FindObjectOfType<LevelLoader>().LoadNextLevel();


    }
    
}
