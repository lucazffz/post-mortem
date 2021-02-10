using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    float transitionTime;

    public void LoadNextLevel() 
    {
        //get legnth of animation
        transitionTime = transition.GetCurrentAnimatorStateInfo(0).length;

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ReloadCurrentLevel()
    {
        //get legnth of animation
        transitionTime = transition.GetCurrentAnimatorStateInfo(0).length;

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadLevel(int levelIndex) 
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
