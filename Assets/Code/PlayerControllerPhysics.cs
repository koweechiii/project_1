using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerPhysics : MonoBehaviour
{

    public Rigidbody body;
    public float movespeed = 1f;
    public float jumpspeed = 1f;
    public string floortag = "floor";
    bool isGrounded = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        isGrounded = false;







    }

    // Update is called once per frame
    void Update()
    {


        Move();







    }


    void Move()
    {

        if (Keyboard.current[Key.W].isPressed)
        {
            //body.AddForce(new Vector3(0,movespeed,0),ForceMode.Force);
         
        }
        if (Keyboard.current[Key.A].isPressed)
        {
            body.AddForce(new Vector3(-movespeed, 0, 0), ForceMode.Force);

        }
        if (Keyboard.current[Key.S].isPressed)
        {
            body.AddForce(new Vector3(0, -movespeed, 0), ForceMode.Force);

        }
        if (Keyboard.current[Key.D].isPressed)
        {
            body.AddForce(new Vector3(movespeed, 0, 0), ForceMode.Force);

        }
        if (Keyboard.current[Key.Space].wasPressedThisFrame)
        {

            if (isGrounded == true)
            {
                body.AddForce(new Vector3(0, jumpspeed, 0), ForceMode.Impulse);
                isGrounded = false;
            }


        }



 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(floortag))
        {
            isGrounded=true;
        }
    }
}
