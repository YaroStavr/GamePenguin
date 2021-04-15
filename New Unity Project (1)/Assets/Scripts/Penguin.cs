using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour 
{
    private Rigidbody2D rb;
    public float  speed;
    public float jumpHeight;
    public Animator animator;
    public bool Ground;
    private bool facingRight;
    public float normalSpeed;
   
    
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        animator.SetFloat ("vSpeed", rb.velocity.y);
        animator.SetBool("LeftRight", false );

       if(Ground)
        {
            animator.SetBool("Ground", true);
            animator.SetBool("Jump 1", false ); // проверка находится ли персонаж в воздухе после прыжка
        }
        else animator.SetBool("Ground", false);
        //-------------------------------------------------Настройка-кнопок-на-экране-------------------------------------------------
        


        //---------------------------------------------------Конец-настройки-кнопок---------------------------------------------------
        if(Input.GetKeyDown(KeyCode.Space)&&Ground&&!Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.A))//--------Прыжок/рывок при АФК
                {                                      
                    rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                    animator.SetBool("Jump 1", true );
                }
        
        
        if(Input.GetKey(KeyCode.D))//----------------------------------------------------------------------------Право
        {                                       
            if(!facingRight)Flip();
            rb.AddForce(transform.right * speed, ForceMode2D.Impulse);   
            animator.SetBool("LeftRight", true); 
                
            if(Input.GetKeyDown(KeyCode.Space)&&Ground)//--------------------------------------------------------Прыжок/рывок
            {                                      
                rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                animator.SetTrigger("Jump");
                animator.SetBool("Jump 1", true );
            }
        }else
            if(Input.GetKey(KeyCode.A))//------------------------------------------------------------------------Лево
            {   
                if(facingRight)Flip();                   
                rb.AddForce(-transform.right * speed, ForceMode2D.Impulse);
                animator.SetBool("LeftRight", true);
                if(Input.GetKeyDown(KeyCode.Space)&&Ground)//-----------------------------------------------------Прыжок/рывок
                {                                      
                    rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                    animator.SetTrigger("Jump");
                    animator.SetBool("Jump 1", true );
                }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    /*public void OnLeftButtonDown()
    {
        if(speed>=0f)
        {
            speed = -normalSpeed;
        }
    }
    public void OnRightButtonDown()
    {
        if(speed <=0f)
        {
            speed = normalSpeed;
        }
    }*/



}
