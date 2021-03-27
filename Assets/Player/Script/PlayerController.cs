using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement(){
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {   
            //Cuando se mueve
            gameObject.GetComponent<Animator>().SetBool("ismovement", true);
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
}
