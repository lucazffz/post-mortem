using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //variables
    public Animator transition;
    private float transitionTime;
    
    private void Start()
    {
        //get legnth of animation
        transitionTime = transition.GetCurrentAnimatorStateInfo(0).length;
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ReloadCurrentLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));

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
