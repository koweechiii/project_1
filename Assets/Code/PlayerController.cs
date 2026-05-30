
using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public GameObject player;
    public int number;



    private int number67;
    int number69;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       

    }


    // Update is called once per frame
    void Update()
    {
      
        Move();





    }
    /// <summary>
    /// movingtheplayer
    /// </summary>

    void Move()
    {
        //Debug.Log("movecalled");
        Vector3 movement = new Vector3(0,0,0);
        if (Keyboard.current[Key.W].isPressed)
        {
            //Debug.Log("up");
            movement.y = movement.y + 1;


        }
        if (Keyboard.current[Key.A].isPressed)
        {
            //Debug.Log("left");
            movement.x = movement.x - 1;
        }
        if (Keyboard.current[Key.S].isPressed)
        {
            //Debug.Log("down");
            movement.y = movement.y - 1;
        }
        if (Keyboard.current[Key.D].isPressed)
        {
            //Debug.Log("right");
            movement.x = movement.x + 1;
        }
        player.transform.position = movement;
        
    }














}