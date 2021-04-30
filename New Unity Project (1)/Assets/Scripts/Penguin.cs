using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour 
{
    private Rigidbody2D rb;
    public float  speed;
    public float speedMobile;
    public float jumpHeight;
    public float moveInput;
    public Animator animator;
    public bool Ground;
    private bool facingRight;
    public float normalSpeed;

    public Joystick joystick; 
   public float n;
    
    void Start()
    {
        //speed=0f;
        rb=GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        var MaxSpeed = rb.velocity.magnitude;
        
        //--------------------------------Кнопки для телефона----------------------------------------
        //float h = Input.GetAxisRaw("Horizontal");
        moveInput = joystick.Horizontal;
        //rb.AddForce(Vector2.right * h * speed);
        //rb.velocity = new Vector2(moveInput * speedMobile, rb.velocity.y);

        //--------------------------------------Конец------------------------------------------------

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
                    //rb.velocity = new Vector2(rb.velocity.y*speed, rb.velocity.y);
                    rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                    animator.SetBool("Jump 1", true );
                }
        
        
        if(Input.GetKey(KeyCode.D)||moveInput>0.01f)//----------------------------------------------------------------------------Право
        {                                       
            if(!facingRight)Flip();
            //moveInput = Input.GetAxisRaw("Horizontal");
            //rb.velocity = new Vector2(moveInput*speedMobile, rb.velocity.y);
            //if(MaxSpeed<10||Jump)
            rb.AddForce(transform.right * speed, ForceMode2D.Force);
            MaxSpeed = rb.velocity.magnitude;   
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
            Debug.Log("Speed: "+MaxSpeed);
            if(facingRight)
                Flip();                  
            rb.AddForce(-transform.right * speed, ForceMode2D.Impulse);
            MaxSpeed = rb.velocity.magnitude;
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
