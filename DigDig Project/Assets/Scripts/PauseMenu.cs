﻿using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    #region Variables

    public Animator animator;
    public UnityEvent switchMenu;

    private float animationLength;
    public static bool isPaused;

    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Resume();
    }

    public void Resume()
    {
        isPaused = !isPaused;

        gameObject.transform.GetChild(0).gameObject.SetActive(isPaused);
        animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        StartCoroutine(WaitForAnimation());

        if (isPaused)
        {
            animator.SetBool("isOpen", true);
            Time.timeScale = 0;
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
            animator.SetBool("isOpen", false);
            Time.timeScale = 1;
        }
    }

    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(animationLength);
        switchMenu.Invoke();
    }
}