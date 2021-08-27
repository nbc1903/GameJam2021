using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementForce;
    public float jumpForce;

    public float raycastDistance;
    public LayerMask groundMask;

    private Rigidbody2D rb;

    public Transform head;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xDir * (movementForce * Time.deltaTime), rb.velocity.y);
        if (xDir != 0) { head.localScale = new Vector3(xDir, 1f, 1f); }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("trying to jump");
            if (isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
            }
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundMask);
        Debug.Log("return grounded: " + hit.collider);
        return hit.collider;
    }
}
