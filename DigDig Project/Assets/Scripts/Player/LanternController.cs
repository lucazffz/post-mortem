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
                //transform.GetChild(0).gameObject.SetActive(true);

                GetComponent<CapsuleCollider2D>().enabled = false;

                transform.position = lanternHolder.position;
                transform.parent = lanternHolder;

                GetComponent<Rigidbody2D>().isKinematic = true;

                transform.localScale = lanternHolder.localScale;

                
            }
            else
            {
                //transform.GetChild(0).gameObject.SetActive(false);

                //transform.parent = null;
                GetComponent<Rigidbody2D>().isKinematic = false;
                GetComponent<CapsuleCollider2D>().enabled = true;

                transform.localScale = new Vector3(transform.localScale.x, 1);
            }
        }
        else canHoldLantern = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Grabbable")
        {
            transform.parent = collision.gameObject.transform;

            transform.position = new Vector2(collision.gameObject.transform.position.x, transform.position.y);








        }
    }
}