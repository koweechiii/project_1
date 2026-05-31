using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerTranslate : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float jumpStr = 1f;
    public float gravity = 1f;
    public Transform player;
    Vector3 velocity;
    public float maxVelocity;
    public float fallMultiplier;
    public float maxFallSpeed = -20f;

    private void Update()
    {
        Move();
        Gravity();

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


        }
           
            
    }
        void Move()
    {

        Vector3 movement = Vector3.zero;

        movement.x = ReadInput().x;
        movement.y = velocity.y;

        player.position += movement * moveSpeed * Time.deltaTime;
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



}