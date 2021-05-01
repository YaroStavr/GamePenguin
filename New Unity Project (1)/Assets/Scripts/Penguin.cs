using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour 
{
    private Rigidbody2D rb;
    private Rigidbody rbb;
    private Collider2D coll;
    public float  speed;
    public float normalSpeed;
    public float jumpHeight;
    public float moveInput;
    public Animator animator;
    public bool Ground;
    private bool facingRight;



    public Joystick joystick; 
    
    void Start()
    {
        //speed=0f;
        rb=GetComponent<Rigidbody2D>();
        rbb = GetComponent<Rigidbody>();
        coll = gameObject.GetComponent<Collider2D>();
    }
    
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        //-------------------------------------------
        //moveInput = joystick.Horizontal;

        animator.SetFloat ("vSpeed", rb.velocity.y);
        animator.SetBool("LeftRight", false );

       if(Ground)
        {
            animator.SetBool("Ground", true);
            animator.SetBool("Jump 1", false ); // проверка находится ли персонаж в воздухе после прыжка
        }
        else animator.SetBool("Ground", false);
        
        
        if(Input.GetKeyDown(KeyCode.Space)&&Ground&&!Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.A))//--------Прыжок/рывок при АФК
        {                                      
            rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
            animator.SetBool("Jump 1", true );
        }
        
        
        if(Input.GetKey(KeyCode.D)||moveInput>0.01f)//----------------------------------------------------------------------------Право
        {                                       
            if(!facingRight)
                Flip();

            if(rb.velocity.magnitude<normalSpeed)
                rb.AddForce(new Vector2(speed,0), ForceMode2D.Force);
            else
                rb.velocity = new Vector2(moveInput*normalSpeed, rb.velocity.y);

            //Debug.Log("Speed: "+rb.velocity.magnitude);

            animator.SetBool("LeftRight", true);     
            if(Input.GetKeyDown(KeyCode.Space)&&Ground)//--------------------------------------------------------Прыжок/рывок
            {                                 
                rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                animator.SetTrigger("Jump");
                animator.SetBool("Jump 1", true );
            }
        }else
        
        if(Input.GetKey(KeyCode.A)||moveInput<-0.01f)//------------------------------------------------------------------------Лево
        {   
            if(facingRight)
                Flip();

            if(rb.velocity.magnitude<normalSpeed)
                rb.AddForce(new Vector2(-speed,0), ForceMode2D.Force);
            else
                rb.velocity = new Vector2(moveInput*normalSpeed, rb.velocity.y);

            //Debug.Log("Speed: "+rb.velocity.magnitude);

            animator.SetBool("LeftRight", true);
            if(Input.GetKeyDown(KeyCode.Space)&&Ground)//-----------------------------------------------------Прыжок/рывок
            {                                      
                rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                animator.SetTrigger("Jump");
                animator.SetBool("Jump 1", true );
            }
        }
    }

    public void JumpJump()
    {
        if(Ground)rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
