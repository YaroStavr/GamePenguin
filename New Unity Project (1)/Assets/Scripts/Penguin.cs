using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour 
{
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public float  speed;
    public float jumpHeight;
    public Animator animator;
    
    public bool Ground;
    private Vector2 change;
   
    // Start is called before the first frame update
    
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {

        
        animator.SetFloat ("vSpeed", rb.velocity.y);
 //       animator.SetBool("Up", false );
 //       animator.SetBool("Down", false);
//        animator.SetBool("UpAD", false );
  //      animator.SetBool("DownAD", false );
        animator.SetBool("LeftRight", false );
        
        if(Ground)
        {
            animator.SetBool("Ground", true);
        
        }
        else animator.SetBool("Ground", false);
        
        
        //change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyDown(KeyCode.Space)&&Ground&&!Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.A))//--------------------Прыжок/рывок
                {                                      
                    rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                    //animator.SetFloat ("vSpeed", rb.velocity.y);
                }
        
        
        if(Input.GetKey(KeyCode.D))//--------------------Прыжок/рывок
            {                                       
                rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
                //transform.rotation = Quaternion.Euler(0, 180 ,0);
                animator.SetBool("LeftRight", true); 
                
                if(Input.GetKeyDown(KeyCode.Space)&&Ground)//--------------------Прыжок/рывок
                {                                      
                    rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                    animator.SetTrigger("Jump");
                    //Falling();
                }
            }else
        if(Input.GetKey(KeyCode.A))//--------------------Прыжок/рывок
            {                    
                rb.AddForce(-transform.right * speed, ForceMode2D.Impulse);
                //transform.rotation = Quaternion.Euler(0, 0 ,0); 
                animator.SetBool("LeftRight", true);
                if(Input.GetKeyDown(KeyCode.Space)&&Ground)//--------------------Прыжок/рывок
                {                                      
                    rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
                    animator.SetTrigger("Jump");
                   // Falling();
                }
            }
            
        /*if(change.x>0.01f)//------------------------------------------Вперед
        {                                           
            animator.SetBool("Up", true );
            if(change.x<-0.01f||change.x>0.01f) //--------------------Запуск анимации по диагонали вниз-вбок
            {                                        
                animator.SetBool("UpAD", true );
            }
            if((Input.GetKeyDown(KeyCode.Space))&&(Input.GetKey("w")))//--------------------Прыжок/рывок
            {                                       
                animator.SetTrigger("Jump" );
            }
        } else 
        if(change.x<-0.01f) //----------------------------------------Назад
        {                                           
            animator.SetBool("Down", true );
            if(change.x<-0.01f||change.x>0.01f)//---------------------Запуск анимации по диагонали вниз-вбок
            {                                       
                animator.SetBool("DownAD", true );
            }
            if((Input.GetKeyDown(KeyCode.Space))&&(Input.GetKey("s")))//--------------------Прыжок/рывок
            {                                       
                animator.SetTrigger("Jump" );
            }
        }/*
        if(change.x<-0.01f)//-----------------------------------------Влево
        {                                           
            transform.rotation = Quaternion.Euler(0, 0 ,0);
            animator.SetBool("LeftRight",true);

            if(Input.GetKeyDown(KeyCode.Space))//---------------------Прыжок/рывок
            {                                       
                animator.SetTrigger("Jump" );
            }
            if(change.y>0.01f)//--------------------------------------Запуск анимации по диагонали вверх-вбок 
            {                                       
                animator.SetBool("UpAD", true );
            }else 
            if(change.y<-0.01f)//-------------------------------------Запуск анимации по диагонали вниз-вбок
            {                                        
                    animator.SetBool("DownAD", true );
            }
        } else if(change.x>0.01f)//----------------------------------Вправо
        {                                           
            transform.rotation = Quaternion.Euler(0, 180 ,0);
            animator.SetBool("LeftRight",true);
            if(change.y>0.01f)//-------------------------------------Запуск анимации по диагонали вверх-вбок 
            {                                       
                animator.SetBool("UpAD", true );//-------------------Запуск анимации по диагонали вниз-вбок
            }else 
            if(change.y<-0.01f)
            {                                        
                animator.SetBool("DownAD", true );
            }
            if(Input.GetKeyDown(KeyCode.Space))//--------------------Прыжок/рывок
            {                                       
                animator.SetTrigger("Jump" );
            }
        }  */
    } 
    
    
}
