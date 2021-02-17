using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDistance;
    public static bool holding;

    public LayerMask layerMask;

    

    public string[] prompt = new string[] { "Grab", "Release" };
   
    private void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * boxHolder.parent.localScale.x, rayDistance, layerMask);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Grabbable" ||holding)
        {
            if (Input.GetKeyDown(KeyCode.E)) holding = !holding;

            if (holding)
            {
                transform.GetChild(0).gameObject.SetActive(true);

                transform.position = boxHolder.position;
                transform.parent = boxHolder;

                GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);

                transform.parent = null;
                GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }    
}