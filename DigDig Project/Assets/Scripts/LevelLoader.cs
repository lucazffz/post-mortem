using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //variables
    public Animator transition;
    private float transitionTime;

    public void LoadNextLevel()
    {
        //get legnth of animation
        transitionTime = transition.GetCurrentAnimatorStateInfo(0).length;

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //start animation
        transition.SetTrigger("Start");

        //wait for animation to end
        yield return new WaitForSeconds(transitionTime);

        //load next level
        SceneManager.LoadScene(levelIndex);
    }
}
