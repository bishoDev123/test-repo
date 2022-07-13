using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //empty rigid body 2D variable
    private Rigidbody2D rb;

    //variable is set to public to be able to access it in unity
    public float playerSpeed = 7f;
    public float jumpForce = 7f;

    private float direction;

    public bool touchingGround;

    public Collider2D groundColl;

    // Start is called before the first frame update
    void Start()
    {
        touchingGround = false;
        //assign the rigid body component in the object in unity to the variable rb
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //gets the horizontal input which is going to be 1 or -1
        direction = Input.GetAxis("Horizontal");

        //changes the celocity of the player in the x axis and the y axis remain the same
        rb.velocity = new Vector2(playerSpeed * direction, rb.velocity.y);

        //Moves player vertically. In other words, a jump
        if (Input.GetButtonDown("Jump") && touchingGround)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider == groundColl)
        {
            touchingGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider == groundColl)
        {
            touchingGround = false;
        }
    }

}
