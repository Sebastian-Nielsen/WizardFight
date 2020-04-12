using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using dir = Enums.Direction;

public class Player : MonoBehaviour
{
    public float speed;  // How fast the player moves
    public float jumpForce; // How high the player can jump

    private bool _isFacingRight = true;  // The direction the player is facing
    private bool _isGrounded;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    private float moveInput;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal"); // Arrow left/right [RA = int(-1); RA = int(1)]

        // Set the speed of the player
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void Update()
    {
        /*
         * Turn movement
         */
        if (moveInput > 0) // Turn right
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            _isFacingRight = true;
        }
        else if (moveInput < 0) // Turn left
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            _isFacingRight = false;
        }

        /*
         * Jump movement
         */
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        /*
         * Attack movement
         */
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (_isFacingRight)
                transform.Find("wand").rotation = Quaternion.Euler(0f, 0f, -45f);
            else
                transform.Find("wand").transform.rotation = Quaternion.Euler(0f, 0f, 45f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (_isFacingRight)
                transform.Find("wand").transform.rotation = Quaternion.Euler(0f, 0f, -135f);
            else
                transform.Find("wand").transform.rotation = Quaternion.Euler(0f, 0f, 135f);
        }
        else
        {
            if (_isFacingRight)
                transform.Find("wand").transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            else
                transform.Find("wand").transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

    }

    public bool isFacingRight()
    {
        return _isFacingRight;
    }
}
