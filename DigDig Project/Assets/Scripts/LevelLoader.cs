using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator animator;
    float transitionTime;

    public void Start()
    {
        transitionTime = animator.GetCurrentAnimatorStateInfo(0).length;
    }

    public void LoadNextLevel() 
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ReloadCurrentLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    IEnumerator LoadLevel(int levelIndex) 
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
