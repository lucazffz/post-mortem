using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    private Vector3 posA;

    private Vector3 posB;

    private Vector3 nexPos;

    public bool Activate;

    [SerializeField]
    private float speed;

    [SerializeField]
    public Transform childTransform;

    [SerializeField]
    public Transform transformB;
    public Transform transformA;

    private void Start()
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nexPos = posB;
    }
    void Update()
    {
        if (Activate)
        {
            childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime);
            if (Vector3.Distance(childTransform.localPosition, nexPos) <= 0.1)
            {
                ChangePos();
                Debug.Log("2");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Activate = true;
        }
    }
    public void ChangePos()
    {
        Activate = false;
        if (nexPos == posA)
            nexPos = posB;
        else if(nexPos == posB)
            nexPos = posA;
        Activate = false;
    }
}
