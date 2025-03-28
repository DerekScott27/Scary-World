using System.Collections;
using System.Collections.Generic;    
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;     //Private means that this field/variable can only be accessed within the same class it is declared.
    private float speed = 8f;    //So the horizontal, speed etc. can only be accessed within the PlayerMovement class

                                //8f: This is the initializer, which sets the initial value of the field to 8.0.
                                //The f suffix indicates that the literal value is a float.
    private float jumpingPower = 8f;
    public bool isFacingRight = true;
    public Weapon weapon;
    public Collider2D playerCollider;
        

    [SerializeField] private Rigidbody2D rb;        //Declares a variable named rb of type/class Rigidbody2D, which is a 2D rigidbody component in Unity.
                                                    //SerializeField: This attribute allows the field to be serialized, which means its value can be saved and loaded by Unity.
    [SerializeField] private Transform groundCheck;

    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }
        horizontal = Input.GetAxisRaw("Horizontal"); //1. creating a variable called horizontal, then use the builtin class "input" and function GetAxisRaw, 

                                                     //2. and putting Horizontal as the parameter

                                                     //3. GetAxisRaw - access the value of a virtual axis defined in the Input Manager, like "Horizontal" or "Vertical",
                                                                       //for instant reactions to player input, like menu navigation or quick character movement. 
        
        
        if (Input.GetButtonDown("Jump")&& IsGrounded())  //1. if statement, saying input class - GetButtonDown function with parameter Jump and includes the IsGrounded function

                                                        //2. GetButtonDown - a function used to check if a virtual button (like a keyboard key) has just been pressed down in the current frame

                                                        //3. if (Inputclass.GetbuttondownFunction to check if a button is pressed("Paramter named Jump")
                                   
                                                        //4. && checks if the object is currently touching the ground. 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower); //1. rb.linearVelocity = the actual velocity of an rb object. (Rigidbody2d is the class, rb is the object)
        }
                                                                                //2. So this says the velocity of the rb object is given a value of new Vector2

                                                                                //3. new is an operator (like void) that simply creates a new object or instance of a type

                                                                                //4. Vector2 is a struct like an array.

                                                                                //5. The parameters in the struct are linear velocity.x and jumpingPower (the variable we created earlier)

                                                                                //6. rb.linearVelocity.x: This takes the current x-component of the Rigidbody's linear velocity

       // if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
      //  {
      //      rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.2f);
      //  }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
                                                                                  //1. rb.linearVelocity is accessing the linearVelocity property of the Rigidbody2D class (rb)
                                                                                            // linearvelocity is specfiically a vector, so a quantity expressed in more than 1 number

                                                                                  //2. "new Vector2" creates a Vector2 object. Vector2 represents a 2D vector with x and y components.
                                                                                         // vector is a term that refers to quantities that cannot be expressed by a single number

                                                                                //3. horizontal * speed is calling the variables i made earlier
                                                                                
                                                                                //4. rb.linearVelocity.y: is keeping the current y-component of the velocity unchanged.

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
      
        }

    }
}
