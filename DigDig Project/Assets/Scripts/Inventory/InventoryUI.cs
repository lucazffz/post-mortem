using UnityEngine;
using System.Collections;

public class InventoryUI : MonoBehaviour
{ 
    public GameObject inventoryMenu;

    private Animator animator;

    public static InventoryUI instance;

    private void Start()
    {
        animator = GetComponent<Animator>();
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !DialogueManager.inConversaion && !PauseMenu.pauseMenuActivated)
        {
            if (InventoryManager.instance.inventoryActivated) Resume();
            else Pause();
        }

        if (PauseMenu.pauseMenuActivated) Resume();
    }
    
    public void Resume()
    {
        animator.SetBool("isOpen", false);
        if(!PauseMenu.pauseMenuActivated) Time.timeScale = 1.0f;
        InventoryManager.instance.inventoryActivated = false;
    }

    public void Pause()
    {
        animator.SetBool("isOpen", true);
        Time.timeScale = 0.0f;
        InventoryManager.instance.inventoryActivated = true;
    }
}
