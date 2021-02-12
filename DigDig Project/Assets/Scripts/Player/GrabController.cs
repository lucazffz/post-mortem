using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDistance;
    public bool holding;

    

    public string[] prompt = new string[] { "Grab", "Release" };
   
    private void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDistance);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Grabbable")
        {
            if (Input.GetKeyDown(KeyCode.C)) holding = !holding;


            FindObjectOfType<InteractableManager>().eventPrompt = prompt;
            FindObjectOfType<InteractableManager>().canInteract = true;
            FindObjectOfType<InteractableManager>().eventIndex = 0;

            if (holding)
            {
                FindObjectOfType<InteractableManager>().eventIndex = 1;

                grabCheck.collider.gameObject.transform.parent = boxHolder;

                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
       



    }    
}