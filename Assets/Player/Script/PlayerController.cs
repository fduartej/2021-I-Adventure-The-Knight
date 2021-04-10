using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20f;
    public bool isGrounded = false;
    public bool isAttacking = false;
    public float jumpForce = 400f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        Movement();
        Jump();
    }

    private void Movement(){
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {   
            gameObject.GetComponent<Animator>().SetBool("ismovement", true);
            gameObject.GetComponent<Animator>().SetBool("isattack", false);
            Vector3 movement = new Vector3(
                 Input.GetAxis("Horizontal"),
                 0f, 0f);
            transform.position +=
                movement * moveSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftArrow)){
                gameObject.GetComponent<SpriteRenderer>().flipX = true;    
            }else if( Input.GetKey(KeyCode.RightArrow)){
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }

        }
         if (!Input.GetKey(KeyCode.LeftArrow) &&
            !Input.GetKey(KeyCode.RightArrow)
            )
        {
            //Cuando esta idle
            gameObject.GetComponent<Animator>().SetBool("ismovement", false);
           
        }
    }

    void Jump(){
        
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded){
             gameObject.GetComponent<Animator>().SetBool("isjumping", true);
             gameObject.GetComponent<Rigidbody2D>().AddForce(
                 new Vector2(0f, jumpForce), ForceMode2D.Impulse
             );
        } 
        if(!Input.GetKey(KeyCode.UpArrow)){
            gameObject.GetComponent<Animator>().SetBool("isjumping", false);
            
        }
 
    }

    void Attack(){
         if(Input.GetKeyDown(KeyCode.X)){
             gameObject.GetComponent<Animator>().SetBool("isattack", true);
         }
     }

    private void OnCollisionEnter2D(Collision2D otherObject) {
        
        if(otherObject.collider.tag == "Floor" ){
            isGrounded = true; 
        }
    }

    private void OnCollisionExit2D(Collision2D otherObject) {
        
        if(otherObject.collider.tag == "Floor" ){
            isGrounded = false; 
        }
    }
}
