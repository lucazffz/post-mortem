using UnityEngine;

public class LanternController : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDistance;
    public static bool holdingLantern;

    public LayerMask layerMask;

    public static bool canHoldLantern;

    public string[] grabPrompt = new string[] { "grab" };
   
    private void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * boxHolder.parent.localScale.x, rayDistance, layerMask);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Grabbable"|| holdingLantern && PlayerBehavior.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.E) && !DialogueManager.inConversaion && !PauseMenu.isPaused) holdingLantern = !holdingLantern;

            canHoldLantern = true;

            InteractableManager.eventPrompt = grabPrompt;
            InteractableManager.eventIndex = 0;

            if (holdingLantern)
            {
                canHoldLantern = false;
                transform.GetChild(0).gameObject.SetActive(true);

                transform.position = boxHolder.position;
                transform.parent = boxHolder;

                GetComponent<Rigidbody2D>().isKinematic = true;

                transform.localScale = boxHolder.localScale;

                
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