using UnityEngine;

public class GrabController : MonoBehaviour
{
    public static GrabController instance;

    public RaycastHit2D grabCheck;
    public LayerMask layerMask;
    public Transform grabDetect;
    public Transform grabHolder;
    public float rayDistance;

    [HideInInspector] public Transform grabPositionRight;
    [HideInInspector] public Transform grabPositionLeft;

    public static bool grabbing;
    public static bool canGrab;

    private KeyCode grabKey = KeyCode.E;
    [HideInInspector] public string[] grabPrompt = new string[] { "grab" };

    Vector2 endPosition;
    float distance = 1;
   
    private void Update()
    {
        grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * grabHolder.parent.localScale, rayDistance, layerMask);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Grabbable" && PlayerBehavior.isGrounded)
        {
            grabPositionRight = grabCheck.collider.gameObject.transform.GetChild(0);
            grabPositionLeft = grabCheck.collider.gameObject.transform.GetChild(1);

            canGrab = true;
            InteractableManager.eventPrompt = grabPrompt;
            InteractableManager.eventIndex = 0;
            InteractableManager.interactKey = grabKey;

            if (Input.GetKeyDown(grabKey)) grabbing = !grabbing;

            if (grabbing)
            {
                canGrab = false;

                


                grabCheck.collider.GetComponent<Rigidbody2D>().isKinematic = true;
                grabCheck.collider.transform.parent = grabHolder;


                if (distance != 0)
                {
                    if (transform.position.x < grabCheck.collider.transform.position.x) distance = grabPositionLeft.position.x - grabHolder.position.x;
                    else distance = grabPositionRight.position.x - grabHolder.position.x;

                    endPosition = new Vector2(grabCheck.collider.transform.position.x - distance, grabCheck.collider.transform.position.y);

                    grabCheck.collider.transform.position = Vector3.MoveTowards(grabCheck.collider.transform.position, endPosition, 3 * Time.deltaTime);
                }
                
               
            }
            else
            {
                grabCheck.collider.transform.parent = null;
                grabCheck.collider.GetComponent<Rigidbody2D>().isKinematic = false;
                distance = 1;
            }
        }
        else canGrab = false;
    }
}
