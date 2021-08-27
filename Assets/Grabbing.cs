using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : MonoBehaviour
{
    public Rigidbody2D hand;

    private GameObject currentlyHolding;
    private bool canGrab;
    private FixedJoint2D joint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canGrab = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            canGrab = false;
        }

        if(!canGrab && currentlyHolding != null)
        {

            FixedJoint2D[] joints = currentlyHolding.GetComponents<FixedJoint2D>();
            for (int i = 0; i < joints.Length; i++) {
                if(joints[i].connectedBody == hand)
                {
                    Destroy(joints[i]);
                }
            }
            joint = null;
            currentlyHolding = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canGrab && collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            if (collision.gameObject.layer == 8)
            {
                currentlyHolding = collision.gameObject;
                joint = currentlyHolding.AddComponent<FixedJoint2D>();
                joint.connectedBody = hand;
            }
        }
    }
}
