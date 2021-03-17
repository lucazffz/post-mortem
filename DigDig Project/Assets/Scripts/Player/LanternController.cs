using UnityEngine;

public class LanternController : MonoBehaviour
{
    public Transform grabDetect;
    public Transform lanternHolder;
    public float rayDistance;
    public static bool holdingLantern;

    public LayerMask layerMask;

    public static bool canHoldLantern;

    public string[] grabPrompt = new string[] { "hold" };
   
    private void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * lanternHolder.parent.parent.parent.localScale, rayDistance, layerMask);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Lantern" || holdingLantern )
        {
            if (Input.GetKeyDown(KeyCode.E) && !DialogueManager.inConversaion && !PauseMenu.pauseMenuActivated && !InventoryManager.instance.inventoryActivated && PlayerBehavior.isGrounded) holdingLantern = !holdingLantern;

            canHoldLantern = true;

            InteractableManager.eventPrompt = grabPrompt;
            InteractableManager.eventIndex = 0;
            InteractableManager.interactKey = KeyCode.E;

            if (holdingLantern)
            {
                canHoldLantern = false;
                transform.GetChild(0).gameObject.SetActive(true);

                transform.position = lanternHolder.position;
                transform.parent = lanternHolder;

                GetComponent<Rigidbody2D>().isKinematic = true;

                transform.localScale = lanternHolder.localScale;

                
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);

                transform.parent = null;
                GetComponent<Rigidbody2D>().isKinematic = false;

                transform.localScale = new Vector3(transform.localScale.x, 1);
            }
        }
        else canHoldLantern = false;
    }    
}