using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerControllerTranslate : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpStr = 1f;
    public float doubleJumpStr = 1f;
    public float gravity = 1f;
    public Transform player;
    Vector3 velocity;
    public float maxVelocity;
    public float fallMultiplier;
    public float maxFallSpeed = -20f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.5f;
    public LayerMask groundLayer;
    public int maxJump = 3;
    bool hasJumpedInAir = false;
    int airJump = 0;
    public int numberOfJumps = 0;
    public Animator anim;


    private void Update()
        {
            Move();
            Jump();

            Gravity();
            StopFalling();
    }
    Vector3 ReadInput()
    {
        Vector3 newPos = Vector3.zero;
        if (Keyboard.current[Key.W].isPressed)
        {
            newPos.y += 1;

        }
        if (Keyboard.current[Key.A].isPressed)
        {
            newPos.x -= 1;

        }
        if (Keyboard.current[Key.S].isPressed)
        {
            newPos.y -= 1;

        }
        if (Keyboard.current[Key.D].isPressed)
        {
            newPos.x += 1;

        }
        return newPos;
    }
    void Jump()
        {
            if (Keyboard.current[Key.Space].wasPressedThisFrame) 
                {
               
                      if (IsGrounded()) 
                        {
                            hasJumpedInAir = false;
                            velocity.y = jumpStr;
                        
                        }
                    else /// Not Grounded
                        {
                          if (hasJumpedInAir == false)
                            {
                                velocity.y = doubleJumpStr;
                                hasJumpedInAir = true;
                            }
                        }


          

                }
        }

    void Gravity()
    {

        float currentGravity = gravity;

       /* Vector3 gravityfalls = Vector3.zero;
        gravityfalls.y = gravity * Time.deltaTime;
        player.position -= gravityfalls;
      */

        if(velocity.y < 0)
            {
                currentGravity *= fallMultiplier;
            }

        velocity.y -= currentGravity * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, maxFallSpeed);

    }

    void Move()
        {
            Vector3 movement = Vector3.zero;

            movement.x = ReadInput().x;
            movement.y = velocity.y;
            
            CtrlAnimator(movement);

            
            player.position += movement * moveSpeed * Time.deltaTime;
        }

    void CtrlAnimator(Vector3 recivedMovement)
    {
        ///check if player is moving left/right
        ///check if player is falling/jumping
        ///

        if (recivedMovement.x < 0)
        {
            anim.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            anim.transform.eulerAngles = new Vector3(0, 0, 0);

        }


        if (recivedMovement.x == 0)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isFalling", false);
            anim.SetBool("isJumping", false);

            Debug.Log("player is not moving");
        }
        else
        {

            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", true);
            anim.SetBool("isFalling", false);
            anim.SetBool("isJumping", false);

            Debug.Log("player is moving");
        }


        if (recivedMovement.y < 0)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isFalling", true);
            anim.SetBool("isJumping", false);

            Debug.Log("player is falling");
        }
        else if(recivedMovement.y > 0)
                {
            
                    Debug.Log(  "player is jumping");

                    anim.SetBool("isIdle", false);
                    anim.SetBool("isRunning", false);
                    anim.SetBool("isFalling", false);
                    anim.SetBool("isJumping", true);
                }


        }

    /// <summary>
    ///  we check if were are on the ground using checkShpere, if the ground is in side the check sphere radius we are "grounded"
    ///  if were are "grounded" we make sure to stop moving down
    /// </summary>
    bool IsGrounded()
        {
            return Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer, QueryTriggerInteraction.Ignore);
        }

    void StopFalling()
        {
            if (IsGrounded())
                {
                    if (velocity.y < 0)
                        {
                            velocity.y = 0;
                        }
                }
        }


}