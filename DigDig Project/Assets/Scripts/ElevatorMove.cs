using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nexPos;

    public bool activate;

    [SerializeField]
    private float speed;

    [SerializeField]
    public Transform childTransform;

    [SerializeField]
    public Transform transformB;
    public Transform transformA;

    private void Start()
    {
        posA = transformA.localPosition;
        posB = transformB.localPosition;
        nexPos = posB;
    }
    void Update()
    {
        if (activate)
        {
            childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime);

            if (Vector3.Distance(childTransform.localPosition, nexPos) <= 0.1)
            {
                ChangePos();
            }
        }
    }
    public void Activate()
    {
        Debug.Log("hit");
        activate = true;
    }
    public void ChangePos()
    {
        activate = false;
        if (nexPos == posA) nexPos = posB;
        else if(nexPos == posB) nexPos = posA;
    }
}
