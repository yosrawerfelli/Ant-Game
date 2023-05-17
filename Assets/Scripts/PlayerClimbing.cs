using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbing : MonoBehaviour
{
   private float vertical;
   private float speed = 8f;
   private bool isClimb;
   private bool isClimbing;
   public PlayerMovement movement;
   private int faced;
   

   [SerializeField] private Rigidbody2D rb;
   private Animator anim;

   private void Start() 
   {
    anim = GetComponent<Animator>();
    
   }



    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        
           if(movement.horizontal > 0f)
            {
                faced = 1;
            }

            if(movement.horizontal < 0f)
            {
                faced = -1;
            }

        if (isClimb && Mathf.Abs(vertical)> 0f)
        {
            isClimbing =true;
            if(faced > 0f)
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            }

            if(faced < 0f)
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
            }
            
        }

        
        
    }

    private void FixedUpdate() 
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
            
            if (Mathf.Abs(vertical)> 0f)
            {
                Debug.Log("it works");
                anim.SetBool ("isWalking", true);
            }
            else
            {
                anim.SetBool ("isWalking", false);
            }
        }
        else
        {
            rb.gravityScale = 5f;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Climb"))
        {
            isClimb = true;
            

        }
        
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Climb"))
        {
            isClimb = false;
            isClimbing = false;
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        
    }
}
