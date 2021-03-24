using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public Transform top;
    public Transform bottom;

    enum EleStates {goup, godown, still};
    EleStates states;

    public float smooth;

    Vector2 newPos;

    bool hasPlayer;

    void Start()
    {
        states = EleStates.still;
    }

    
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.U) && hasPlayer)
        {
            states = EleStates.goup;
        }
        else if (Input.GetKeyDown(KeyCode.I) && hasPlayer)
        {
            states = EleStates.godown;
        }
        FMS();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Player")
        {
            coll.transform.parent = gameObject.transform;
            hasPlayer = true;
        }
    }
    private void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            coll.transform.parent = null;
            hasPlayer = false;
        }
    }
    void FMS()
    {
        if (states == EleStates.godown)
        {
            newPos = bottom.position;
            transform.position = Vector2.Lerp(transform.position, newPos, smooth * Time.deltaTime);
            Debug.Log("Down");
        }
        else if (states == EleStates.goup)
        {
            newPos = top.position;
            transform.position = Vector2.Lerp(transform.position, newPos, smooth * Time.deltaTime);
            Debug.Log("Up");
        }
        // (states == EleStates.godown)
      }
}
