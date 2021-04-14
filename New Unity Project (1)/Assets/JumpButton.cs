using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{

    private Animation animator;
    private Rigidbody2D rb;
    private float jumpHeight;
    private float speed;
    
    void Start()
    {
        jumpHeight = GetComponent<Penguin>().jumpHeight;
        rb=GetComponent<Rigidbody2D>();
        speed = GetComponent<Penguin>().speed;
    }

    public void JumpJump()
    {
        rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        //rb.AddForce(new Vector2(rb.velocity.x, jumpHeight));
    }
    public void Right(bool Right)
    {

        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        
    }
    
    public void Left(bool Left)
    {
        rb.AddForce(-transform.right * speed, ForceMode2D.Impulse);   
    }
    
}
