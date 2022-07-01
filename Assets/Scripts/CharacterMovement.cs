using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    private new Rigidbody rigidbody;
    private float distanceToGround;

    public float speed;
    public float runSpeed = 10f;
    public float jumpSpeed; 

    void Start()
    {

        rigidbody = GetComponent<Rigidbody>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;

    }

    public void UpdateMovement()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 velocity;

        if (horizontal != 0 || vertical != 0) {

            

            if(Input.GetButton("Sprint")){

                velocity = (transform.forward * vertical + transform.right * horizontal).normalized * runSpeed;

            }
            else{

                velocity = (transform.forward * vertical + transform.right * horizontal).normalized * speed;

            }
            
        }
        else {

           velocity = Vector3.zero;

        }

        velocity. y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;

    }

    private bool IsGrounded()
    {
        return Physics.BoxCast(transform.position, new Vector3(0.4f, 0f, 0.4f), Vector3.down, Quaternion.identity, distanceToGround + 0.1f);
    }

    private void UpdateJump()
    {

        if (Input.GetButtonDown("Jump") && IsGrounded()){

            rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);

        }

    }

    void Update()
    {
        
        UpdateMovement();
        UpdateJump();

    }
}
