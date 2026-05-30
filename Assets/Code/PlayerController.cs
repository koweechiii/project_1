
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       

    }


    // Update is called once per frame
    void Update()
    {

        Move();





    }


    void Move()
    {
        Debug.Log("movecalled");
        Vector3 movement = new Vector3(0,0,0);
        if (Keyboard.current[Key.W].isPressed)
        {
            Debug.Log("up");

        }
        if (Keyboard.current[Key.A].isPressed)
        {
            Debug.Log("left");

        }
        if (Keyboard.current[Key.S].isPressed)
        {
            Debug.Log("down");

        }
        if (Keyboard.current[Key.D].isPressed)
        {
            Debug.Log("right");

        }

    }














}